using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AserAgence.Data;
using AserAgence.Models;

namespace AserAgence.Controllers
{
    public class VillageController : Controller
    {
        private readonly AserAgenceDbContext _context;

        public VillageController(AserAgenceDbContext context)
        {
            _context = context;
        }

        // GET: Village
        public async Task<IActionResult> Index()
        {
            var aserAgenceDbContext = _context.Village.Include(v => v.Commune).Include(v => v.Department).Include(v => v.Region);
            return View(await aserAgenceDbContext.ToListAsync());
        }

        // GET: Village/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Village == null)
            {
                return NotFound();
            }

            var village = await _context.Village
                .Include(v => v.Commune)
                .Include(v => v.Department)
                .Include(v => v.Region)
                .FirstOrDefaultAsync(m => m.VillageID == id);
            if (village == null)
            {
                return NotFound();
            }

            return View(village);
        }

        // GET: Village/Create
        public IActionResult Create()
        {
            ViewData["CommuneID"] = new SelectList(_context.Commune, "Id", "Id");
            ViewData["DepartmentID"] = new SelectList(_context.Department, "Id", "Id");
            ViewData["RegionID"] = new SelectList(_context.Region, "Id", "Id");
            return View();
        }

        // POST: Village/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VillageID,VillageCode,ElectrifiedHouseholds,Longitude,Latitude,IsElelctrify,RegionID,DepartmentID,CommuneID")] Village village)
        {
            if (ModelState.IsValid)
            {
                _context.Add(village);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommuneID"] = new SelectList(_context.Commune, "Id", "Id", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(_context.Department, "Id", "Id", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(_context.Region, "Id", "Id", village.RegionID);
            return View(village);
        }

        // GET: Village/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Village == null)
            {
                return NotFound();
            }

            var village = await _context.Village.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }
            ViewData["CommuneID"] = new SelectList(_context.Commune, "Id", "Id", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(_context.Department, "Id", "Id", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(_context.Region, "Id", "Id", village.RegionID);
            return View(village);
        }

        // POST: Village/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VillageID,VillageCode,ElectrifiedHouseholds,Longitude,Latitude,IsElelctrify,RegionID,DepartmentID,CommuneID")] Village village)
        {
            if (id != village.VillageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(village);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillageExists(village.VillageID))
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
            ViewData["CommuneID"] = new SelectList(_context.Commune, "Id", "Id", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(_context.Department, "Id", "Id", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(_context.Region, "Id", "Id", village.RegionID);
            return View(village);
        }

        // GET: Village/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Village == null)
            {
                return NotFound();
            }

            var village = await _context.Village
                .Include(v => v.Commune)
                .Include(v => v.Department)
                .Include(v => v.Region)
                .FirstOrDefaultAsync(m => m.VillageID == id);
            if (village == null)
            {
                return NotFound();
            }

            return View(village);
        }

        // POST: Village/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Village == null)
            {
                return Problem("Entity set 'AserAgenceDbContext.Village'  is null.");
            }
            var village = await _context.Village.FindAsync(id);
            if (village != null)
            {
                _context.Village.Remove(village);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillageExists(int id)
        {
          return (_context.Village?.Any(e => e.VillageID == id)).GetValueOrDefault();
        }
    }
}
