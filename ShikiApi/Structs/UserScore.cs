using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserScore
    {
        public string Name { get; set; }
        [JsonProperty("value")]
        public int Count { get; set; }
    }
}