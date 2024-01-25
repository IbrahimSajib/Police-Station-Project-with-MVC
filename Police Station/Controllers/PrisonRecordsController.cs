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
    public class PrisonRecordsController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public PrisonRecordsController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var policeStationDbContext = _context.PrisonRecords.Include(p => p.Criminal).Include(p => p.Prison);
            return View(await policeStationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisonRecord = await _context.PrisonRecords
                .Include(p => p.Criminal)
                .Include(p => p.Prison)
                .FirstOrDefaultAsync(m => m.PrisonRecordId == id);
            if (prisonRecord == null)
            {
                return NotFound();
            }

            return View(prisonRecord);
        }

        public IActionResult Create()
        {
            ViewData["CriminalId"] = new SelectList(_context.Criminals, "CriminalId", "Name");
            ViewData["PrisonId"] = new SelectList(_context.Prisons, "PrisonId", "PrisonName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrisonRecordId,CriminalId,PrisonId,EntryDate,ReleaseDate,ReasonForImprisonment,Status")] PrisonRecord prisonRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prisonRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CriminalId"] = new SelectList(_context.Criminals, "CriminalId", "Name", prisonRecord.CriminalId);
            ViewData["PrisonId"] = new SelectList(_context.Prisons, "PrisonId", "PrisonName", prisonRecord.PrisonId);
            return View(prisonRecord);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisonRecord = await _context.PrisonRecords.FindAsync(id);
            if (prisonRecord == null)
            {
                return NotFound();
            }
            ViewData["CriminalId"] = new SelectList(_context.Criminals, "CriminalId", "Name", prisonRecord.CriminalId);
            ViewData["PrisonId"] = new SelectList(_context.Prisons, "PrisonId", "PrisonName", prisonRecord.PrisonId);
            return View(prisonRecord);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrisonRecordId,CriminalId,PrisonId,EntryDate,ReleaseDate,ReasonForImprisonment,Status")] PrisonRecord prisonRecord)
        {
            if (id != prisonRecord.PrisonRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prisonRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrisonRecordExists(prisonRecord.PrisonRecordId))
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
            ViewData["CriminalId"] = new SelectList(_context.Criminals, "CriminalId", "Name", prisonRecord.CriminalId);
            ViewData["PrisonId"] = new SelectList(_context.Prisons, "PrisonId", "PrisonName", prisonRecord.PrisonId);
            return View(prisonRecord);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisonRecord = await _context.PrisonRecords
                .Include(p => p.Criminal)
                .Include(p => p.Prison)
                .FirstOrDefaultAsync(m => m.PrisonRecordId == id);
            if (prisonRecord == null)
            {
                return NotFound();
            }

            return View(prisonRecord);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prisonRecord = await _context.PrisonRecords.FindAsync(id);
            if (prisonRecord != null)
            {
                _context.PrisonRecords.Remove(prisonRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisonRecordExists(int id)
        {
            return _context.PrisonRecords.Any(e => e.PrisonRecordId == id);
        }
    }
}
