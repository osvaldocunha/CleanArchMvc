using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Commands
{
    public class TransactionRemoveCommand : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public string Sku { get; set; }
        public TransactionRemoveCommand(string sku)
        {
            Sku = sku;
        }
    }
}
