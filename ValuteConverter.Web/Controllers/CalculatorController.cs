using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValuteConverter.Core.Services.CalulatorServices;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Web.Controllers;

public class CalculatorController : Controller
{
    private readonly ICalculatorService _calculatorService;
    private readonly ICurrencyService _currencyService;
    public CalculatorController(
        ICalculatorService calculatorService, 
        ICurrencyService currencyService)
    {
        _calculatorService = calculatorService;
        _currencyService = currencyService;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var tosend = new GetAllCurrencyDto();
        ViewBag.Currencies = new SelectList(await _currencyService.GetAllList(tosend), "Id", "Name");
        return View(new CalculatorDto());
    }

    [HttpPost]
    public async Task<ActionResult> Index(CalculatorDto input)
    {
        var tosend = new GetAllCurrencyDto();
        ViewBag.Currencies = new SelectList(await _currencyService.GetAllList(tosend), "Id", "Name");
        input = await _calculatorService.Calculate(input);
        return View(input);
}
}
