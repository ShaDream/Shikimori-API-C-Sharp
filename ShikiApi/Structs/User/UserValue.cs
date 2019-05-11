using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserValue
    {
        public string Name { get; set; }
        [JsonProperty("value")]
        public int Count { get; set; }
    }
}