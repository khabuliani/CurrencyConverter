namespace ValuteConverter.Domain.Shared.Paging;

public interface IPagedResultRequest
{
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
}
