using AserAgence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using AserAgence.Repositories;
using AserAgence.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AserAgence.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IVillageRepository _villageRepository;

        public SurveyController(ISurveyRepository surveyRepository, IVillageRepository villageRepository)
        {
            _surveyRepository = surveyRepository;
            _villageRepository = villageRepository;
        }

        // GET: Survey
        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyRepository.GetAllAsync();
            return View(surveys.ToList());
        }

        // GET: Survey/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveyRepository.GetByIdAsync(id.Value);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Survey/Create
        public IActionResult Create()
        {
            ViewData["VillageID"] = new SelectList(_villageRepository.GetAllAsync().Result, "VillageID", "VillageName");
            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurveyDate,ElectrifiedHouseholdsSurveyed,VillageID")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                await _surveyRepository.CreateAsync(survey);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VillageID"] = new SelectList(_villageRepository.GetAllAsync().Result, "VillageID", "VillageName", survey.VillageID);
            return View(survey);
        }

        // GET: Survey/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveyRepository.GetByIdAsync(id.Value);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["VillageID"] = new SelectList(_villageRepository.GetAllAsync().Result, "VillageID", "VillageID", survey.VillageID);
            return View(survey);
        }

        // POST: Survey/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyDate,ElectrifiedHouseholdsSurveyed,VillageID")] Survey survey)
        {
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _surveyRepository.UpdateAsync(survey);
                }
                catch
                {
                    if (!SurveyExists(survey.Id))
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
            ViewData["VillageID"] = new SelectList(_villageRepository.GetAllAsync().Result, "VillageID", "VillageID", survey.VillageID);
            return View(survey);
        }

        // GET: Survey/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveyRepository.GetByIdAsync(id.Value);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Survey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _surveyRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(int id)
        {
            return _surveyRepository.ExistsAsync(id).Result;
        }
    }
}
