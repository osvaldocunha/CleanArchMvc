using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Transactions.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<TransactionDTO, TransactionCreateCommand>();
            CreateMap<TransactionDTO, TransactionUpdateCommand>();
        }
    }
}
