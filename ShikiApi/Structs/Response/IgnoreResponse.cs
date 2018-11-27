using Newtonsoft.Json;

namespace ShikiApi
{
    public class IgnoreResponse
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("is_ignored")]
        public bool IsIgnored { get; set; }
    }
}