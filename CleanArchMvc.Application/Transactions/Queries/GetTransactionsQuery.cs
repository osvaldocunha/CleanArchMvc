using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Transactions.Queries
{
    public class GetTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {
    }
}
