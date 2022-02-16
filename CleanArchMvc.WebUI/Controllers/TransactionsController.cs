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
            ViewBag.sku =
            new SelectList(await _rateService.GetRates(), "From", "To");

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
        public async Task<IActionResult> Edit(string sku)
        {
            if (sku == null) return NotFound();
            var transactionDto = await _transactionService.GetById(sku);

            if (transactionDto == null) return NotFound();

            var rates = await _rateService.GetRates();
            ViewBag.sku = new SelectList(rates, "sku", "USD", transactionDto.Sku);
           
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

       // [Authorize(Roles ="Admin")]
        [HttpGet()]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var transactionDto = await _transactionService.GetById(id);

            if (transactionDto == null) return NotFound();

            return View(transactionDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _transactionService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var transactionDto = await _transactionService.GetById(id);

  

            return View(transactionDto);
        }
    }
}
