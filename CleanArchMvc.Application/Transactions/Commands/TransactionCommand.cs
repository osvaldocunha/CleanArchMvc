using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Commands
{
    public abstract class TransactionCommand : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public string Sku { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

    }
}
