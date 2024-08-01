namespace ValuteConverter.Core.Dto;

public class CurrencyCourseDto
{
    public int Id { get; set; }
    public int CurrencyId { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal BuyingPrice { get; set; }
}
