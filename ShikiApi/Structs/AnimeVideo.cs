using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeVideo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("player_url")]
        public string PlayerUrl { get; set; }
        public string Name { get; set; }
        public AnimeVideoKind Kind { get; set; }
        public string Hosting { get; set; }
    }
}