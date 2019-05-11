using Newtonsoft.Json;

namespace ShikiApi
{
    public class PersonWork
    {
        [JsonProperty("anime")]
        public Anime Anime { get; set; }

        [JsonProperty("manga")]
        public Manga Manga { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}