namespace Shared.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public long TotalCount { get; set; }
    }
}
