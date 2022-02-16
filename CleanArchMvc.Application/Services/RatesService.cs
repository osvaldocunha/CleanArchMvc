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
        private IRatesRepository _categoryRepository;
        private readonly IMapper _mapper;
        public RatesService(IRatesRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatesDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<RatesDTO>>(categoriesEntity);
        }

        public async Task<RatesDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<RatesDTO>(categoryEntity);
        }

        public async Task Add(RatesDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Rates>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
        }

        public async Task Update(RatesDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Rates>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(categoryEntity);
        }
    }
}
