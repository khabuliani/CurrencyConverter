namespace ValuteConverter.Domain.Shared.Paging;

public class PagedDto : IPagedResultRequest
{
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
}
