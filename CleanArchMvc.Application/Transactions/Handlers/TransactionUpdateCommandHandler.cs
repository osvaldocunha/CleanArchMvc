using CleanArchMvc.Application.Transactions.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Transactions.Handlers
{
    public class TransactionUpdateCommandHandler : IRequestHandler<TransactionUpdateCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionUpdateCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository ??
            throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Transaction> Handle(TransactionUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Sku);

            if (transaction == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                //transaction.Update(request.Sku, request.Amount, request.Currency);

                return await _transactionRepository.UpdateAsync(transaction);

            }
        }
    }
}
