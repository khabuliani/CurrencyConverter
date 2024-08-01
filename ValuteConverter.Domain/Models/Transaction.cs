namespace ValuteConverter.Domain.Models;

public class Transaction 
{
    public int Id { get; set; }
    public int ToSellCurrencyId { get; set; }
    public decimal ToSell { get; set; }
    public Currency ToSellCurrency { get; set; }
    public int ToBuyCurrencyId { get; set; }
    public Currency ToBuyCurrency { get; set; }
    public decimal ToBuy { get; set; }
    public int? CreatorClientId { get; set; }
    public Client CreatorClient { get; set; }
    public DateTime CreationDate { get; set; }
}
