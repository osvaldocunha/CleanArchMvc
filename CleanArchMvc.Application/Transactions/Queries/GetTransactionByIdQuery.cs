using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Transactions.Queries
{
    public class GetTransactionByIdQuery : IRequest<CleanArchMvc.Domain.Entities.Transaction>
    {
        public string  Sku { get; set; }
        public GetTransactionByIdQuery(string sku)
        {
            Sku = sku;
        }
    }
}
