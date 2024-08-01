using AutoMapper;
using ValuteConverter.Core.Dto;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CurrencyDto, Currency>().ReverseMap();
        CreateMap<CurrencyCourseDto, CurrencyCourse>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
    }
}
