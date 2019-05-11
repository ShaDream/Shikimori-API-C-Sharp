using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class CalendarInfo
    {
        [JsonProperty("next_episode")]
        public int NextEpisode { get; set; }
        //TODO: i don't know how to calculate this to minutes
        [JsonProperty("next_episode_at")]
        public DateTime NextEpisodAt { get; set; }
        public string Duration { get; set; }
        public Anime Anime { get; set; }
    }
}