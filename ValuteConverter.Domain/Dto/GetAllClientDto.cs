using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Domain.Dto;

public class GetAllClientDto : PagedDto
{
    public string? PersonalNumber { get; set; }
}
