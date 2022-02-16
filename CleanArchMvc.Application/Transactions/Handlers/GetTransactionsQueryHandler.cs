using CleanArchMvc.Application.Transactions.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Transactions.Handlers
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<CleanArchMvc.Domain.Entities.Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<CleanArchMvc.Domain.Entities.Transaction>> Handle(GetTransactionsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetTransactionsAsync();
        }
    }
}
