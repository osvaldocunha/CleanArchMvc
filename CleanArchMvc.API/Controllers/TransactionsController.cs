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
            var produtos = await _transactionService.GetTransactions();
            if (produtos == null)
            {
                return NotFound("Transactions not found");
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "GetTransaction")]
        public async Task<ActionResult<TransactionDTO>> Get(int id)
        {
            var produto = await _transactionService.GetById(id);
            if (produto == null)
            {
                return NotFound("Transaction not found");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransactionDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _transactionService.Add(produtoDto);

            return new CreatedAtRouteResult("GetTransaction",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TransactionDTO produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _transactionService.Update(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionDTO>> Delete(int id)
        {
            var produtoDto = await _transactionService.GetById(id);

            if (produtoDto == null)
            {
                return NotFound("Transaction not found");
            }

            await _transactionService.Remove(id);

            return Ok(produtoDto);
        }
    }
}
