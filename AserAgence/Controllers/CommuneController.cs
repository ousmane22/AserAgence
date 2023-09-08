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
    public class CommuneController : Controller
    {
        private readonly AserAgenceDbContext _context;

        public CommuneController(AserAgenceDbContext context)
        {
            _context = context;
        }

        // GET: Commune
        public async Task<IActionResult> Index()
        {
              return _context.Commune != null ? 
                          View(await _context.Commune.ToListAsync()) :
                          Problem("Entity set 'AserAgenceDbContext.Commune'  is null.");
        }

        // GET: Commune/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Commune == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // GET: Commune/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commune/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Commune commune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commune);
        }

        // GET: Commune/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Commune == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune.FindAsync(id);
            if (commune == null)
            {
                return NotFound();
            }
            return View(commune);
        }

        // POST: Commune/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Commune commune)
        {
            if (id != commune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuneExists(commune.Id))
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
            return View(commune);
        }

        // GET: Commune/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Commune == null)
            {
                return NotFound();
            }

            var commune = await _context.Commune
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // POST: Commune/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Commune == null)
            {
                return Problem("Entity set 'AserAgenceDbContext.Commune'  is null.");
            }
            var commune = await _context.Commune.FindAsync(id);
            if (commune != null)
            {
                _context.Commune.Remove(commune);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuneExists(int id)
        {
          return (_context.Commune?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
