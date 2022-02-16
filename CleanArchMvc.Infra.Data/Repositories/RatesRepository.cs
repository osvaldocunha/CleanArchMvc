using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class RatesRepository : IRatesRepository
    {
        private ApplicationDbContext _rateContext;
        public RatesRepository(ApplicationDbContext context)
        {
            _rateContext = context;
        }

        public async Task<Rates> Create(Rates rate)
        {
            _rateContext.Add(rate);
            await _rateContext.SaveChangesAsync();
            return rate;
        }

        public async Task<Rates> GetById(int? id)
        {
            var rate = await _rateContext.Rates.FindAsync(id);
            return rate;
        }

        public async Task<IEnumerable<Rates>> GetRates()
        {
            return await _rateContext.Rates.ToListAsync();
        }

        public async Task<Rates> Remove(Rates rate)
        {
            _rateContext.Remove(rate);
            await _rateContext.SaveChangesAsync();
            return rate;
        }

        public async Task<Rates> Update(Rates rate)
        {
            _rateContext.Update(rate);
            await _rateContext.SaveChangesAsync();
            return rate;
        }
    }
}
