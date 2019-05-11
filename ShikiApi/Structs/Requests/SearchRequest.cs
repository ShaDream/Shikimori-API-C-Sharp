using System.Collections.Generic;

namespace ShikiApi
{
    public class SearchRequest : BaseListRequest
    {
        [Request(Name = "search")]
        public string Search { get; set; } = null;
    }
}