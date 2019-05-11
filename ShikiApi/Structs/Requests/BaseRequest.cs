namespace ShikiApi
{
    public class BaseListRequest : Request
    {
        [Request(Name = "page", DefaultValue = 0)]
        public int Page { get; set; } = 0;

        [Request(Name = "limit", DefaultValue = 0)]
        public int Limit { get; set; } = 0;
    }
}