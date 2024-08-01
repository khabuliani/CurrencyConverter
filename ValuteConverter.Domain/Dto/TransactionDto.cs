namespace ValuteConverter.Domain.Dto;

public class TransactionDto
{
    public int Id { get; set; }
    public int ToSellCurrencyId { get; set; }
    public decimal ToSell{ get; set; }
    public int ToBuyCurrencyId { get; set; }
    public decimal ToBuy { get; set; }
    public int? CreatorClientId { get; set; }
    public DateTime CreationDate { get; set; }
}
