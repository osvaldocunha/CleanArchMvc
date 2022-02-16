using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Queries
{
    public class GetTransactionByIdQuery : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public int Id { get; set; }
        public GetTransactionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
