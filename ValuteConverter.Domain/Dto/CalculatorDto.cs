namespace ValuteConverter.Domain.Dto;

public class CalculatorDto
{
    public int ToSellCurrencyId { get; set; }
    public decimal ToSell { get; set; }
    public int ToBuyCurrencyId { get; set; }
    public decimal ToBuy { get; set; }
}
