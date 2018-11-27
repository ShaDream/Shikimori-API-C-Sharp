using System.Collections.Generic;

namespace ShikiApi
{
    public class SearchRequest : Request
    {
        [String("page")]
        [DefaultValue(0)]
        public int Page { get; set; } = 0;
        [String("limit")]
        [DefaultValue(0)]
        public int Limit { get; set; } = 0;
        [String("search")]
        public string Search { get; set; } = null;
    }
}