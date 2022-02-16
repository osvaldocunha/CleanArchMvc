using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Transactions.Queries;
using CleanArchMvc.Application.Transactions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CleanArchMvc.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILoggerFactory _loggerFactory;
        public TransactionsService(IMapper mapper, IMediator mediator, ILoggerFactory loggerFactory)
        {
            _mapper = mapper;
            _mediator = mediator;
            _loggerFactory = loggerFactory;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactions()
        {
         
            try
            {
                var transactionsQuery = new GetTransactionsQuery();

                if (transactionsQuery == null)
                    throw new Exception($"Entity could not be loaded.");

                var result = await _mediator.Send(transactionsQuery);

                return _mapper.Map<IEnumerable<TransactionDTO>>(result);
            }
            catch (Exception ex)
            {
                _loggerFactory.CreateLogger(ex.Message);
                throw;
            }

        }

        public async Task<TransactionDTO> GetById(string sku)
        {
            var transactionByIdQuery = new GetTransactionByIdQuery(sku);

            if (transactionByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(transactionByIdQuery);

            return _mapper.Map<TransactionDTO>(result);
        }

      

        public async Task Add(TransactionDTO transactionDto)
        {
            var transactionCreateCommand = _mapper.Map<TransactionCreateCommand>(transactionDto);
            await _mediator.Send(transactionCreateCommand);
        }

        public async Task Update(TransactionDTO transactionDto)
        {
            var transactionUpdateCommand = _mapper.Map<TransactionUpdateCommand>(transactionDto);
            await _mediator.Send(transactionUpdateCommand);
        }

        public async Task Remove(string id)
        {
            var transactionRemoveCommand = new TransactionRemoveCommand(id);
            if (transactionRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(transactionRemoveCommand);
        }
    }
}
