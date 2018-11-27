using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class Anime
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Russian { get; set; }
        public Image Image { get; set; }
        public string URL { get; set; }
        public AnimeKind Kind { get; set; }
        public TitleStatus Status { get; set; }
        public int Episoded { get; set; }
        [JsonProperty("episodes_aired")]
        public int EpisodedAired { get; set; }
        [JsonProperty("aired_on")]
        public DateTime? AiredOn { get; set; }
        [JsonProperty("released_on")]
        public DateTime? ReleasedOn { get; set; }
    }
}