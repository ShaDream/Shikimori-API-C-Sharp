using Newtonsoft.Json;

namespace ShikiApi
{
    public class TitleListRequest : SearchRequest
    {
        [Request(Name = "order")]
        public ListOrder? Order { get; set; } = null;
        [Request(Name = "status")]
        public TitleStatus? Status { get; set; } = null;
        [Request(DefaultValue = 0, Name = "score")]
        public int Score { get; set; } = 0;
        [Request(Name = "season")]
        public SeasonPicker Season { get; set; } = null;
        [Request(DefaultValue = true, Name = "censored")]
        public bool Censored { get; set; } = true;
        [Request(Name = "mylist")]
        public UserItemStatus? MyList { get; set; } = null;
        [Request(Name = "ids")]
        public IdsPicker Ids { get; set; } = null;
        [JsonProperty("exclude_ids")]
        [Request(Name = "exclude_ids")]
        public IdsPicker ExcludeIds { get; set; } = null;
    }
}