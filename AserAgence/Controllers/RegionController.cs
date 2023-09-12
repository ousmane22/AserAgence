using AserAgence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AserAgence.Repositories;
using AserAgence.Repositories.Interfaces;

namespace AserAgence.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            var regions = await _regionRepository.GetAllAsync();
            return View(regions);
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _regionRepository.GetByIdAsync(id.Value);

            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionName")] Region region)
        {
            if (ModelState.IsValid)
            {
                await _regionRepository.CreateAsync(region);
                return RedirectToAction(nameof(Index));
            }

            return View(region);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _regionRepository.GetByIdAsync(id.Value);

            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegionName")] Region region)
        {
            if (id != region.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _regionRepository.UpdateAsync(region);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RegionExists(region.Id))
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

            return View(region);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _regionRepository.GetByIdAsync(id.Value);

            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionExists = await RegionExists(id);

            if (!regionExists)
            {
                return NotFound();
            }

            await _regionRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RegionExists(int id)
        {
            return await _regionRepository.ExistsAsync(id);
        }
    }
}
