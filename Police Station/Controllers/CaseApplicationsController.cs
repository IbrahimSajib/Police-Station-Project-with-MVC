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
    public class CaseApplicationsController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public CaseApplicationsController(PoliceStationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Admin,Police")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseApplications.ToListAsync());
        }

        [Authorize(Roles = "Admin,Police")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseApplication = await _context.CaseApplications
                .FirstOrDefaultAsync(m => m.CaseApplicationId == id);
            if (caseApplication == null)
            {
                return NotFound();
            }

            return View(caseApplication);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaseApplication caseApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseApplication);
                await _context.SaveChangesAsync();
                return View("Successful");
            }
            return View(caseApplication);
        }
        [Authorize(Roles = "Admin,Police")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseApplication = await _context.CaseApplications.FindAsync(id);
            if (caseApplication == null)
            {
                return NotFound();
            }
            return View(caseApplication);
        }

        [Authorize(Roles = "Admin,Police")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CaseApplication caseApplication)
        {
            if (id != caseApplication.CaseApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseApplicationExists(caseApplication.CaseApplicationId))
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
            return View(caseApplication);
        }
        [Authorize(Roles = "Admin,Police")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseApplication = await _context.CaseApplications
                .FirstOrDefaultAsync(m => m.CaseApplicationId == id);
            if (caseApplication == null)
            {
                return NotFound();
            }

            return View(caseApplication);
        }

        [Authorize(Roles = "Admin,Police")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseApplication = await _context.CaseApplications.FindAsync(id);
            if (caseApplication != null)
            {
                _context.CaseApplications.Remove(caseApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseApplicationExists(int id)
        {
            return _context.CaseApplications.Any(e => e.CaseApplicationId == id);
        }
    }
}
