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
    public class ReportAnalysisController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public ReportAnalysisController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var policeStationDbContext = _context.ReportAnalysis.Include(r => r.CaseApplication).Include(r => r.PoliceOfficer);
            return View(await policeStationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportAnalysis = await _context.ReportAnalysis
                .Include(r => r.CaseApplication)
                .Include(r => r.PoliceOfficer)
                .FirstOrDefaultAsync(m => m.ReportAnalysisId == id);
            if (reportAnalysis == null)
            {
                return NotFound();
            }

            return View(reportAnalysis);
        }


        public IActionResult Create()
        {
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress");
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportAnalysisId,AnalysisResults,ReportingDate,Conclusions,CaseApplicationId,PoliceOfficerId")] ReportAnalysis reportAnalysis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", reportAnalysis.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", reportAnalysis.PoliceOfficerId);
            return View(reportAnalysis);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportAnalysis = await _context.ReportAnalysis.FindAsync(id);
            if (reportAnalysis == null)
            {
                return NotFound();
            }
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", reportAnalysis.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", reportAnalysis.PoliceOfficerId);
            return View(reportAnalysis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportAnalysisId,AnalysisResults,ReportingDate,Conclusions,CaseApplicationId,PoliceOfficerId")] ReportAnalysis reportAnalysis)
        {
            if (id != reportAnalysis.ReportAnalysisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportAnalysisExists(reportAnalysis.ReportAnalysisId))
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
            ViewData["CaseApplicationId"] = new SelectList(_context.CaseApplications, "CaseApplicationId", "VictimAddress", reportAnalysis.CaseApplicationId);
            ViewData["PoliceOfficerId"] = new SelectList(_context.PoliceOfficers, "PoliceOfficerId", "Name", reportAnalysis.PoliceOfficerId);
            return View(reportAnalysis);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportAnalysis = await _context.ReportAnalysis
                .Include(r => r.CaseApplication)
                .Include(r => r.PoliceOfficer)
                .FirstOrDefaultAsync(m => m.ReportAnalysisId == id);
            if (reportAnalysis == null)
            {
                return NotFound();
            }

            return View(reportAnalysis);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportAnalysis = await _context.ReportAnalysis.FindAsync(id);
            if (reportAnalysis != null)
            {
                _context.ReportAnalysis.Remove(reportAnalysis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportAnalysisExists(int id)
        {
            return _context.ReportAnalysis.Any(e => e.ReportAnalysisId == id);
        }
    }
}
