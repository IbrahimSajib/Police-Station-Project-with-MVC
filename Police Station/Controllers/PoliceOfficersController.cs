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
    public class PoliceOfficersController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public PoliceOfficersController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.PoliceOfficers.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeOfficer = await _context.PoliceOfficers
                .FirstOrDefaultAsync(m => m.PoliceOfficerId == id);
            if (policeOfficer == null)
            {
                return NotFound();
            }

            return View(policeOfficer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PoliceOfficer policeOfficer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policeOfficer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policeOfficer);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeOfficer = await _context.PoliceOfficers.FindAsync(id);
            if (policeOfficer == null)
            {
                return NotFound();
            }
            return View(policeOfficer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  PoliceOfficer policeOfficer)
        {
            if (id != policeOfficer.PoliceOfficerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policeOfficer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliceOfficerExists(policeOfficer.PoliceOfficerId))
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
            return View(policeOfficer);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeOfficer = await _context.PoliceOfficers
                .FirstOrDefaultAsync(m => m.PoliceOfficerId == id);
            if (policeOfficer == null)
            {
                return NotFound();
            }

            return View(policeOfficer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policeOfficer = await _context.PoliceOfficers.FindAsync(id);
            if (policeOfficer != null)
            {
                _context.PoliceOfficers.Remove(policeOfficer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliceOfficerExists(int id)
        {
            return _context.PoliceOfficers.Any(e => e.PoliceOfficerId == id);
        }
    }
}
