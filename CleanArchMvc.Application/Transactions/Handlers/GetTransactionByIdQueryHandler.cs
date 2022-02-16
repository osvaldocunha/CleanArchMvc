using CleanArchMvc.Application.Transactions.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Transactions.Handlers
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, CleanArchMvc.Domain.Entities.Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository; 
        }

        public async Task<CleanArchMvc.Domain.Entities.Transaction> Handle(GetTransactionByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetByIdAsync(request.Id);
        }
    }
}
