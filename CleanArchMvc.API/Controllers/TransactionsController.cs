using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionService;
       public TransactionsController(ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> Get()
        {
            var transactions = await _transactionService.GetTransactions();
            if (transactions == null)
            {
                return NotFound("Transactions not found");
            }
            return Ok(transactions);
        }

        [HttpGet("{sku}", Name = "GetTransaction")]
        public async Task<ActionResult<TransactionDTO>> Get(string sku)
        {
            var produto = await _transactionService.GetById(sku);
            if (produto == null)
            {
                return NotFound("Transaction not found");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null)
                return BadRequest("Data Invalid");

            await _transactionService.Add(transactionDTO);

            return new CreatedAtRouteResult("GetTransaction",
                new {sku = transactionDTO.Sku }, transactionDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] TransactionDTO transactionDTO)
        {
            if (id != transactionDTO.Sku)
            {
                return BadRequest("Data invalid");
            }

            if (transactionDTO == null)
                return BadRequest("Data invalid");

            await _transactionService.Update(transactionDTO);

            return Ok(transactionDTO);
        }

        [HttpDelete("{sku}")]
        public async Task<ActionResult<TransactionDTO>> Delete(string  sku)
        {
            var transactionDTO = await _transactionService.GetById(sku);

            if (transactionDTO == null)
            {
                return NotFound("Transaction not found");
            }

            await _transactionService.Remove(sku);

            return Ok(transactionDTO);
        }
    }
}
