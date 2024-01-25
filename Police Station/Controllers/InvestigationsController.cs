using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Police_Station.Models;
using Police_Station.Models.DbContext;

namespace Police_Station.Controllers
{
    [Authorize(Roles = "Admin,Police")]
    public class InvestigationsController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public InvestigationsController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var policeStationDbContext = _context.InvestigationInfos.Include(i => i.CaseApplication).Include(i => i.PoliceOfficer);
            return View(await policeStationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigationInfo = await _context.InvestigationInfos
                .Include(i => i.CaseApplication)
                .Include(i => i.PoliceOfficer)
                .FirstOrDefaultAsync(m => m.InvestigationInfoId == id);
            if (investigationInfo == null)
            {
                return NotFound();
            }

            return View(investigationInfo);
        }

        public IActionResult Create()
        {
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress");
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( InvestigationInfo investigationInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investigationInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", investigationInfo.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", investigationInfo.PoliceOfficerId);
            return View(investigationInfo);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigationInfo = await _context.InvestigationInfos.FindAsync(id);
            if (investigationInfo == null)
            {
                return NotFound();
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", investigationInfo.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", investigationInfo.PoliceOfficerId);
            return View(investigationInfo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvestigationInfo investigationInfo)
        {
            if (id != investigationInfo.InvestigationInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investigationInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigationInfoExists(investigationInfo.InvestigationInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", investigationInfo.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", investigationInfo.PoliceOfficerId);
            return View(investigationInfo);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigationInfo = await _context.InvestigationInfos
                .Include(i => i.CaseApplication)
                .Include(i => i.PoliceOfficer)
                .FirstOrDefaultAsync(m => m.InvestigationInfoId == id);
            if (investigationInfo == null)
            {
                return NotFound();
            }

            return View(investigationInfo);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigationInfo = await _context.InvestigationInfos.FindAsync(id);
            if (investigationInfo != null)
            {
                _context.InvestigationInfos.Remove(investigationInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigationInfoExists(int id)
        {
            return _context.InvestigationInfos.Any(e => e.InvestigationInfoId == id);
        }
    }
}
