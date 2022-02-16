using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Commands
{
    public abstract class TransactionCommand : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
