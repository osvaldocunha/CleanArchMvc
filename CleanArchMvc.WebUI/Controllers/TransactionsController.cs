using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionsService _transactionService;
        private readonly IRatesService _rateService;
        private readonly IWebHostEnvironment _environment;

        public TransactionsController(ITransactionsService tranasactionAppService,
            IRatesService rateService, IWebHostEnvironment environment)
        {
            _transactionService = tranasactionAppService;
            _rateService = rateService;
            _environment = environment;


        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transactions = await _transactionService.GetTransactions();
            return View(transactions);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId =
            new SelectList(await _rateService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionDTO transactionDto)
        {
            if (ModelState.IsValid)
            {
                await _transactionService.Add(transactionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(transactionDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var transactionDto = await _transactionService.GetById(id);

            if (transactionDto == null) return NotFound();

            var categories = await _rateService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", transactionDto.CategoryId);

            return View(transactionDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(TransactionDTO transactionDto)
        {
            if (ModelState.IsValid)
            {
                await _transactionService.Update(transactionDto);
                return RedirectToAction(nameof(Index));
            }
            return View(transactionDto);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var transactionDto = await _transactionService.GetById(id);

            if (transactionDto == null) return NotFound();

            return View(transactionDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transactionService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var transactionDto = await _transactionService.GetById(id);

            if (transactionDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + transactionDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(transactionDto);
        }
    }
}
