using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ITransactionsService
    {
        Task<IEnumerable<TransactionDTO>> GetTransactions();
        Task<TransactionDTO> GetById(int? id);
        Task Add(TransactionDTO TransactionsDto);
        Task Update(TransactionDTO TransactionsDto);
        Task Remove(int? id);
    }
}
