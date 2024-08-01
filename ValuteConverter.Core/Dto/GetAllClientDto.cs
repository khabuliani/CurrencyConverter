using ValueConverter.Shared.Paging;

namespace ValuteConverter.Core.Dto;

public class GetAllClientDto : PagedDto
{
    public string? PersonalNumber { get; set; }
}
