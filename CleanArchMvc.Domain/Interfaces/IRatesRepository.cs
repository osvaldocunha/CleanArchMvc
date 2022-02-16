using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IRatesRepository
    {
        Task<IEnumerable<Rates>> GetCategories();
        Task<Rates> GetById(int? id);

        Task<Rates> Create(Rates category);
        Task<Rates> Update(Rates category);
        Task<Rates> Remove(Rates category);
    }
}
