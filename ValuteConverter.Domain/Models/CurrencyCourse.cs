namespace ValuteConverter.Domain.Models
{
    public class CurrencyCourse
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
