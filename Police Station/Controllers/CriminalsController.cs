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
    [Authorize(Roles ="Admin,Police")]
    public class CriminalsController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public CriminalsController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var policeStationDbContext = _context.Criminals.Include(c => c.CaseApplication);
            return View(await policeStationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals
                .Include(c => c.CaseApplication)
                .FirstOrDefaultAsync(m => m.CriminalId == id);
            if (criminal == null)
            {
                return NotFound();
            }

            return View(criminal);
        }

        public IActionResult Create()
        {
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criminal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", criminal.CaseApplicationId);
            return View(criminal);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals.FindAsync(id);
            if (criminal == null)
            {
                return NotFound();
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", criminal.CaseApplicationId);
            return View(criminal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Criminal criminal)
        {
            if (id != criminal.CriminalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriminalExists(criminal.CriminalId))
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
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", criminal.CaseApplicationId);
            return View(criminal);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminal = await _context.Criminals
                .Include(c => c.CaseApplication)
                .FirstOrDefaultAsync(m => m.CriminalId == id);
            if (criminal == null)
            {
                return NotFound();
            }

            return View(criminal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criminal = await _context.Criminals.FindAsync(id);
            if (criminal != null)
            {
                _context.Criminals.Remove(criminal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriminalExists(int id)
        {
            return _context.Criminals.Any(e => e.CriminalId == id);
        }
    }
}
