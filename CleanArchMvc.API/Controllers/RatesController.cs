using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _rateService;
        public RatesController(IRatesService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatesDTO>>> Get()
        {
            var rates = await _rateService.GetRates();
            if (rates == null)
            {
                return NotFound("Rates not found");
            }
            return Ok(rates);
        }

        [HttpGet("{id:int}", Name = "GetRate")]
        public async Task<ActionResult<RatesDTO>> Get(int id)
        {
            var rate = await _rateService.GetById(id);
            if (rate == null)
            {
                return NotFound("Rate not found");
            }
            return Ok(rate);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RatesDTO rateDto)
        {
            if (rateDto == null)
                return BadRequest("Invalid Data");

            await _rateService.Add(rateDto);

            return new CreatedAtRouteResult("Getrate", new { id = rateDto.Id },      rateDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] RatesDTO rateDto)
        {
            if (id.Equals( rateDto.Id))
                return BadRequest();

            if (rateDto == null)
                return BadRequest();

            await _rateService.Update(rateDto);

            return Ok(rateDto);
        }          
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RatesDTO>> Delete(int id)
        {
            var rate = await _rateService.GetById(id);
            if(rate == null)
            {
                return NotFound("rate not found");
            }
            
            await _rateService.Remove(id);

            return Ok(rate);

        }
    }
}
