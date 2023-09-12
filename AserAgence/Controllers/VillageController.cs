using AserAgence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using AserAgence.Repositories;
using AserAgence.Repositories.Interfaces;

namespace AserAgence.Controllers
{
    public class VillageController : Controller
    {
        private readonly IVillageRepository _villageRepository;
        private readonly ICommuneRepository _communeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IRegionRepository _regionRepository;

        public VillageController(IVillageRepository villageRepository, ICommuneRepository communeRepository,
            IDepartmentRepository departmentRepository, IRegionRepository regionRepository)
        {
            _villageRepository = villageRepository;
            _communeRepository = communeRepository;
            _departmentRepository = departmentRepository;
            _regionRepository = regionRepository;
        }

        // GET: Village
        public async Task<IActionResult> Index()
        {
            var villages = await _villageRepository.GetAllAsync();
            return View(villages);
        }

        // GET: Village/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _villageRepository.GetByIdAsync(id.Value);

            if (village == null)
            {
                return NotFound();
            }

            return View(village);
        }

        // GET: Village/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CommuneID"] = new SelectList(await _communeRepository.GetAllAsync(), "Id", "CommuneName");
            ViewData["DepartmentID"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "DepartmentName");
            ViewData["RegionID"] = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName");
            return View();
        }

        // POST: Village/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VillageName,ElectrifiedHouseholds,Longitude,Latitude,IsElectrify,RegionID,DepartmentID,CommuneID")] Village village)
        {
            if (ModelState.IsValid)
            {
                var region = await _regionRepository.GetByIdAsync(village.RegionID);
                var department = await _departmentRepository.GetByIdAsync(village.DepartmentID);
                var commune = await _communeRepository.GetByIdAsync(village.CommuneID);

                if (region != null && department != null && commune != null)
                {
                    village.VillageCode = $"{region.Id:D2}{department.Id:D2}{commune.Id:D2}{Guid.NewGuid().ToString().Substring(0, 14)}";

                    await _villageRepository.CreateAsync(village);
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["CommuneID"] = new SelectList(await _communeRepository.GetAllAsync(), "Id", "CommuneName", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "DepartmentName", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", village.RegionID);
            return View(village);
        }

        // GET: Village/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _villageRepository.GetByIdAsync(id.Value);

            if (village == null)
            {
                return NotFound();
            }

            ViewData["CommuneID"] = new SelectList(await _communeRepository.GetAllAsync(), "Id", "CommuneName", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "DepartmentName", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", village.RegionID);

            return View(village);
        }

        // POST: Village/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VillageID,VillageName,VillageCode,ElectrifiedHouseholds,Longitude,Latitude,IsElectrify,RegionID,DepartmentID,CommuneID")] Village village)
        {
            if (id != village.VillageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _villageRepository.UpdateAsync(village);
                }
                catch (Exception)
                {
                    if (!await VillageExists(village.VillageID))
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

            ViewData["CommuneID"] = new SelectList(await _communeRepository.GetAllAsync(), "Id", "CommuneName", village.CommuneID);
            ViewData["DepartmentID"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "DepartmentName", village.DepartmentID);
            ViewData["RegionID"] = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", village.RegionID);

            return View(village);
        }

        // GET: Village/Delete/5
        // GET: Village/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _villageRepository.GetByIdAsync(id.Value);

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
            if (!await VillageExists(id))
            {
                return NotFound();
            }

            await _villageRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VillageExists(int id)
        {
            return await _villageRepository.ExistsAsync(id);
        }
    }
}


