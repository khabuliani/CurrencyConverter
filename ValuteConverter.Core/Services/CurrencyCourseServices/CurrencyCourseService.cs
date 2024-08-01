using AutoMapper;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Extensions;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core.Services.CurrencyCourseServices;

public class CurrencyCourseService : ICurrencyCourseService
{
    private readonly IRepository<CurrencyCourse> _currencyCourse;
    private readonly IMapper _mapper;

    public CurrencyCourseService(
        IRepository<CurrencyCourse> currencyCourse, 
        IMapper mapper)
    {
        _currencyCourse = currencyCourse;
        _mapper = mapper;
    }


    public async Task<CurrencyCourseDto> Create(CurrencyCourseDto input)
    {
        var oldCurrency = _currencyCourse.FirstOrDefault(x => x.CurrencyId == input.CurrencyId);

        if (oldCurrency != null)
        {
            throw new Exception("Course with this currency already exists");
        }

        var client = _mapper.Map<CurrencyCourse>(input);
        client.CreationDate = DateTime.Now;
        input.Id = _currencyCourse.InsertAndGetId(client);
        return input;
    }

    public async Task<CurrencyCourseDto> Update(CurrencyCourseDto input)
    {
        var oldCurrency = _currencyCourse.FirstOrDefault(x => x.Id == input.Id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        oldCurrency.SellingPrice = input.SellingPrice;
        oldCurrency.BuyingPrice = input.BuyingPrice;
        _currencyCourse.Update(oldCurrency);
        return input;
    }

    public async Task<CurrencyCourseDto> Get(int id)
    {
        var oldCurrency = _currencyCourse.GetAllIncluding(x => x.Currency).FirstOrDefault(x => x.Id == id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        var result = _mapper.Map<CurrencyCourseDto>(oldCurrency);
        return result;
    }

    public async Task Delete(int id)
    {
        var oldCurrency = _currencyCourse.FirstOrDefault(x => x.Id == id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        _currencyCourse.Delete(id);
    }

    public async Task<PagedResultDto<CurrencyCourseDto>> GetAll(GetAllCurrencyDto input)
    {
        var currencies = _currencyCourse.GetAll()
                                        .WhereIf(input.Code != null, x => x.Currency.Code == input.Code)
                                        .WhereIf(input.Name != null, x => x.Currency.Name.Contains(input.Name))
                                        .WhereIf(input.NameLatin != null, x => x.Currency.NameLatin.Contains(input.NameLatin));
        var result = new PagedResultDto<CurrencyCourseDto>();
        result.TotalCount = currencies.Count();
        currencies = currencies.PageBy(input);
        result.Items = _mapper.Map<List<CurrencyCourseDto>>(currencies.ToList());
        return result;
    }
}
