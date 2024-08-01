using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core.Services.CalulatorServices;

public class CalculatorService : ICalculatorService
{
    private readonly IRepository<CurrencyCourse> _currencyCourse;
    public CalculatorService(IRepository<CurrencyCourse> currencyCourse)
    {
        _currencyCourse = currencyCourse;
    }

    public async Task<CalculatorDto> Calculate(CalculatorDto input)
    {
        if(input.ToSell == 0)
        {
            return CalculateBuy(input);
        }
        else
        {
            return CalculateSell(input);
        }
    }

    private CalculatorDto CalculateBuy(CalculatorDto input)
    {
        var courseToBuy = _currencyCourse.FirstOrDefault(x => x.Id == input.ToBuyCurrencyId);
        var courseToSell = _currencyCourse.FirstOrDefault(x => x.Id == input.ToSellCurrencyId);
        input.ToSell = (courseToBuy.BuyingPrice * input.ToBuy) / courseToSell.SellingPrice;
        input.ToSell = Math.Round(input.ToSell, 2);
        return input;
    }

    private CalculatorDto CalculateSell(CalculatorDto input)
    {
        var courseToBuy = _currencyCourse.FirstOrDefault(x => x.Id == input.ToBuyCurrencyId);
        var courseToSell = _currencyCourse.FirstOrDefault(x => x.Id == input.ToSellCurrencyId);
        input.ToBuy = (courseToSell.SellingPrice * input.ToSell)/ courseToBuy.BuyingPrice;
        input.ToBuy = Math.Round(input.ToBuy, 2);
        return input;
    }
}
