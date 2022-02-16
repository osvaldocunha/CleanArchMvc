using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class RatesController : Controller
    {
        private readonly IRatesService _rateService;
        public RatesController(IRatesService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rates = await _rateService.GetRates();
            return View(rates);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatesDTO category)
        {
            if (ModelState.IsValid)
            {
                await _rateService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoryDto = await _rateService.GetById(id);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(RatesDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _rateService.Update(categoryDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var categoryDto = await _rateService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rateService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var rateDto = await _rateService.GetById(id);

            if (rateDto == null)
                return NotFound();

            return View(rateDto);
        }
    }
}
