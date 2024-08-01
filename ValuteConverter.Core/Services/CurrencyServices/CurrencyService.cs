using AutoMapper;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Extensions;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core.Services.CurrencyServices;

public class CurrencyService : ICurrencyService
{
    private readonly IRepository<Currency> _currency;
    private readonly IMapper _mapper;
    public CurrencyService(
        IRepository<Currency> currency, 
        IMapper mapper)
    {
        _currency = currency;
        _mapper = mapper;
    }

    public async Task<CurrencyDto> Create(CurrencyDto input)
    {
        var oldCurrency = _currency.FirstOrDefault(x => x.Code == input.Code);

        if (oldCurrency != null)
        {
            throw new Exception("Currency with this Code already exists");
        }

        var client = _mapper.Map<Currency>(input);
        client.CreationDate = DateTime.Now;
        input.Id = _currency.InsertAndGetId(client);
        return input;
    }

    public async Task<CurrencyDto> Update(CurrencyDto input)
    {
        var oldCurrency = _currency.FirstOrDefault(x => x.Id == input.Id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        oldCurrency.NameLatin = input.NameLatin;
        oldCurrency.Name = input.Name;
        oldCurrency.Code = input.Code;
        _currency.Update(oldCurrency);
        return input;
    }

    public async Task<CurrencyDto> Get(int id)
    {
        var oldCurrency = _currency.FirstOrDefault(x => x.Id == id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        var result = _mapper.Map<CurrencyDto>(oldCurrency);
        return result;
    }

    public async Task Delete(int id)
    {
        var oldCurrency = _currency.FirstOrDefault(x => x.Id == id);

        if (oldCurrency == null)
        {
            throw new Exception("Currency not found");
        }

        _currency.Delete(id);
    }

    public async Task<PagedResultDto<CurrencyDto>> GetAll(GetAllCurrencyDto input)
    {
        var currencies = _currency.GetAll()
                                        .WhereIf(input.Code != null,x => x.Code == input.Code)
                                        .WhereIf(input.Name != null,x => x.Name.Contains(input.Name))
                                        .WhereIf(input.NameLatin != null,x => x.NameLatin.Contains(input.NameLatin));
        var result = new PagedResultDto<CurrencyDto>();
        result.TotalCount = currencies.Count();
        currencies = currencies.PageBy(input);
        result.Items = _mapper.Map<List<CurrencyDto>>(currencies.ToList());
        return result;
    }

    public async Task<List<CurrencyDto>> GetAllList(GetAllCurrencyDto input)
    {
        var currencies = _currency.GetAll()
                                        .WhereIf(input.Code != null,x => x.Code == input.Code)
                                        .WhereIf(input.Name != null,x => x.Name.Contains(input.Name))
                                        .WhereIf(input.NameLatin != null,x => x.NameLatin.Contains(input.NameLatin));
        return _mapper.Map<List<CurrencyDto>>(currencies.ToList());
    }
}
