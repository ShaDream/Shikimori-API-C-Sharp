using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserInfoValues
    {
        [JsonProperty("anime")]
        public UserValue[] Anime { get; set; }

        [JsonProperty("manga")]
        public UserValue[] Manga { get; set; }
    }
}