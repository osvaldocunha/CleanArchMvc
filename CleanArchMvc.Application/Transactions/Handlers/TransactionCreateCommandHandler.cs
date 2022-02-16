using CleanArchMvc.Application.Transactions.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Transactions.Handlers
{
    public class TransactionCreateCommandHandler : IRequestHandler<TransactionCreateCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionCreateCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> Handle(TransactionCreateCommand request, 
            CancellationToken cancellationToken)
        {
            var transaction = new Transaction(request.Name, request.Description, request.Price,
                              request.Stock, request.Image);

            if (transaction == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                transaction.CategoryId = request.CategoryId;
                return await _transactionRepository.CreateAsync(transaction);
            }
        }
    }
}
