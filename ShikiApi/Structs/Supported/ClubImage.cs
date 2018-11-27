using Newtonsoft.Json;

namespace ShikiApi
{
    public class ClubImage
    {
        public int Id { get; set; }
        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }
        [JsonProperty("main_url")]
        public string MainUrl { get; set; }
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }
        [JsonProperty("can_destroy")]
        public bool? CanDestroy { get; set; }
    }
}