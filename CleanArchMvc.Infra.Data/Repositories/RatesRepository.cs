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
        private ApplicationDbContext _categoryContext;
        public RatesRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Rates> Create(Rates category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Rates> GetById(int? id)
        {
            var category = await _categoryContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<IEnumerable<Rates>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Rates> Remove(Rates category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Rates> Update(Rates category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
