using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Controllers;

[ApiController]
[Route($"api/[controller]/[action]")]
public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyAppService;
    public CurrencyController(ICurrencyService currencyAppService)
    {
        _currencyAppService = currencyAppService;
    }

    [HttpPost]
    public async Task<CurrencyDto> Create(CurrencyDto input)
    {
        return await _currencyAppService.Create(input);
    }

    [HttpPut]
    public async Task<CurrencyDto> Update(CurrencyDto input)
    {
        return await _currencyAppService.Update(input);
    }

    [HttpGet]
    public async Task<CurrencyDto> Get(int id)
    {
        return await _currencyAppService.Get(id);
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        await _currencyAppService.Delete(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<CurrencyDto>> GetAll(GetAllCurrencyDto input)
    {
        return await _currencyAppService.GetAll(input);
    }
}
