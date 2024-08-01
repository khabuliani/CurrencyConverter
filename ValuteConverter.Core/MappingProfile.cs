using AutoMapper;
using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CurrencyDto, Currency>().ReverseMap();
        CreateMap<CurrencyCourseDto, CurrencyCourse>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();
    }
}
