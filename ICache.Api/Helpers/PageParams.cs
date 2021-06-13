namespace ICache.Api.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 1000;
        public int PageNumber { get; set; } = 1;
        public int pageSize = 1000;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}