using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AserAgence.Data;
using AserAgence.Models;
using AserAgence.Repositories.Interfaces;

namespace AserAgence.Controllers
{
    public class CommuneController : Controller
    {
        
            private readonly ICommuneRepository _communeRepository;

            public CommuneController(ICommuneRepository communeRepository)
            {
                _communeRepository = communeRepository;
            }

            // GET: Commune
            public async Task<IActionResult> Index()
            {
                var communes = await _communeRepository.GetAllAsync();
                return View(communes);
            }

            // GET: Commune/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var commune = await _communeRepository.GetByIdAsync(id.Value);

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
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Commune commune)
            {
                if (ModelState.IsValid)
                {
                    await _communeRepository.CreateAsync(commune);
                    return RedirectToAction(nameof(Index));
                }
                return View(commune);
            }

            // GET: Commune/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var commune = await _communeRepository.GetByIdAsync(id.Value);

                if (commune == null)
                {
                    return NotFound();
                }

                return View(commune);
            }

            // POST: Commune/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Commune commune)
            {
                if (id != commune.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _communeRepository.UpdateAsync(commune);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_communeRepository.ExistsAsync(commune.Id).Result)
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
                if (id == null)
                {
                    return NotFound();
                }

                var commune = await _communeRepository.GetByIdAsync(id.Value);

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
                await _communeRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
