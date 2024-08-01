namespace ValuteConverter.Core.Dto;

public class TransactionsDto
{

    public int Id { get; set; }
    public string SellCurrency { get; set; }
    public decimal ToSell { get; set; }
    public string BuyCurrency { get; set; }
    public decimal ToBuy { get; set; }
    public string CreatorClient { get; set; }
}
