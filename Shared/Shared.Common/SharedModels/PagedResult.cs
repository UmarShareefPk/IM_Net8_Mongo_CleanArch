namespace Shared.Common.SharedModels
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public long TotalCount { get; set; }
    }
}
