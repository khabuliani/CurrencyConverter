namespace ValueConverter.Shared.Paging;

public interface IPagedResultRequest
{
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
}
