using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Domain.Dto;

public class GetAllCurrencyDto: PagedDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string NameLatin { get; set; }
}
