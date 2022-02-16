using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Commands
{
    public class TransactionRemoveCommand : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public int Id { get; set; }
        public TransactionRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
