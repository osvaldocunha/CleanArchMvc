using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IRatesRepository
    {
        Task<IEnumerable<Rates>> GetRates();
        Task<Rates> GetById(int? id);

        Task<Rates> Create(Rates Rate);
        Task<Rates> Update(Rates Rate);
        Task<Rates> Remove(Rates Rate);
    }
}
