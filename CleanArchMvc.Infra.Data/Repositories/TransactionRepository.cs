using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext _transactionContext;
        public TransactionRepository(ApplicationDbContext context)
        {
            _transactionContext = context;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            _transactionContext.Add(transaction);
            await _transactionContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetByIdAsync(int? id)
        {
            return await _transactionContext.Transactions.Include(c => c.Category)
               .SingleOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _transactionContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> RemoveAsync(Transaction transaction)
        {
            _transactionContext.Remove(transaction);
            await _transactionContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _transactionContext.Update(transaction);
            await _transactionContext.SaveChangesAsync();
            return transaction;
        }
    }
}
