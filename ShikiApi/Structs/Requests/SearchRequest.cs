using System.Collections.Generic;

namespace ShikiApi
{
    public class SearchRequest : Request
    {
        [Request(Name = "page", DefaultValue = 0)]
        public int Page { get; set; } = 0;
        [Request(Name = "limit", DefaultValue = 0)]
        public int Limit { get; set; } = 0;
        [Request(Name = "search")]
        public string Search { get; set; } = null;
    }
}