using ValueConverter.Shared.Paging;

namespace ValuteConverter.Core.Dto;

public class GetAlltransactionDto : PagedDto
{
    public string PersonalNumber { get; set; }
    public int? ToSellCurrencyId { get; set; }
    public int? ToBuyCurrencyId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
