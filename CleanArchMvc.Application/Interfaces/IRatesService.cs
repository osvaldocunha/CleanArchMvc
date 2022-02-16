using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IRatesService
    {
        Task<IEnumerable<RatesDTO>> GetCategories();
        Task<RatesDTO> GetById(int? id);
        Task Add(RatesDTO categoryDto);
        Task Update(RatesDTO categoryDto);
        Task Remove(int? id);
    }
}
