using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserInfoStatuses
    {
        [JsonProperty("anime")]
        public UserInfoFullStatuses[] Anime { get; set; }

        [JsonProperty("manga")]
        public UserInfoFullStatuses[] Manga { get; set; }
    }
}