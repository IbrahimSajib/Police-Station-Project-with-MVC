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
    public class PrisonsController : Controller
    {
        private readonly PoliceStationDbContext _context;

        public PrisonsController(PoliceStationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Prisons.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons
                .FirstOrDefaultAsync(m => m.PrisonId == id);
            if (prison == null)
            {
                return NotFound();
            }

            return View(prison);
        }


        public IActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrisonId,PrisonName,Location,Capacity,ContactInfo")] Prison prison)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prison);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons.FindAsync(id);
            if (prison == null)
            {
                return NotFound();
            }
            return View(prison);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrisonId,PrisonName,Location,Capacity,ContactInfo")] Prison prison)
        {
            if (id != prison.PrisonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prison);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrisonExists(prison.PrisonId))
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
            return View(prison);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons
                .FirstOrDefaultAsync(m => m.PrisonId == id);
            if (prison == null)
            {
                return NotFound();
            }

            return View(prison);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prison = await _context.Prisons.FindAsync(id);
            if (prison != null)
            {
                _context.Prisons.Remove(prison);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisonExists(int id)
        {
            return _context.Prisons.Any(e => e.PrisonId == id);
        }
    }
}
