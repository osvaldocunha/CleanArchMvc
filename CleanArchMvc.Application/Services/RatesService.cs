using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class RatesService : IRatesService
    {
        private IRatesRepository _rateRepository;
        private readonly IMapper _mapper;
        public RatesService(IRatesRepository ratesRepository, IMapper mapper)
        {
            _rateRepository = ratesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RatesDTO>> GetRates()
        {
            var rates = await _rateRepository.GetRates();
            return _mapper.Map<IEnumerable<RatesDTO>>(rates);
        }

        public async Task<RatesDTO> GetById(int? id)
        {
            var rate = await _rateRepository.GetById(id);
            return _mapper.Map<RatesDTO>(rate);
        }

        public async Task Add(RatesDTO ratesDto)
        {
            var rate = _mapper.Map<Rates>(ratesDto);
            await _rateRepository.Create(rate);
        }

        public async Task Update(RatesDTO ratesDto)
        {
            var Rate = _mapper.Map<Rates>(ratesDto);
            await _rateRepository.Update(Rate);
        }

        public async Task Remove(int? id)
        {
            var Rate = _rateRepository.GetById(id).Result;
            await _rateRepository.Remove(Rate);
        }
    }
}
