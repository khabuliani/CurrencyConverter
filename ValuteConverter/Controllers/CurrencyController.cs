using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.CurrencyServices;

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
}
