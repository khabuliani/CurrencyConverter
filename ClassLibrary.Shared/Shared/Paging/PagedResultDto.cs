namespace ValuteConverter.Domain.Shared.Paging;

public class PagedResultDto<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}
