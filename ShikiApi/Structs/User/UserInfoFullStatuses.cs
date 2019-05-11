using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserInfoFullStatuses
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("grouped_id")]
        public string GroupedId { get; set; }

        [JsonProperty("type")]
        public TypeOfTitle Type { get; set; }
    }
}