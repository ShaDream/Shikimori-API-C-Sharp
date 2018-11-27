using Newtonsoft.Json;

namespace ShikiApi
{
    public class TopicIgnoreResponse
    {
        [JsonProperty("topic_id")]
        public int TopicId { get; set; }
        [JsonProperty("is_ignored")]
        public bool IsIgnored { get; set; }
    }
}