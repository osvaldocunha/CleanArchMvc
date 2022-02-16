using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IRatesService
    {
        Task<IEnumerable<RatesDTO>> GetRates();
        Task<RatesDTO> GetById(int? id);
        Task Add(RatesDTO rateDto);
        Task Update(RatesDTO rateDto);
        Task Remove(int? id);
    }
}
