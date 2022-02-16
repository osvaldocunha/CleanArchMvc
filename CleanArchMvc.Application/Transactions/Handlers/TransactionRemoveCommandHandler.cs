using CleanArchMvc.Application.Transactions.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Transactions.Handlers
{
    public class TransactionRemoveCommandHandler : IRequestHandler<TransactionRemoveCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionRemoveCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository ?? throw new
                ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Transaction> Handle(TransactionRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _transactionRepository.RemoveAsync(transaction);
                return result;
            }
        }
    }
}
