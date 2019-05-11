using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeInfo : Anime
    {
        public Rating Rating { get; set; }
        public string[] English { get; set; }
        public string[] Japanese { get; set; }
        public string[] Synonyms { get; set; }
        public int? duration { get; set; }
        public float? Score { get; set; }
        public string Description { get; set; }
        [JsonProperty("description_html")]
        public string DescriptionHTML { get; set; }
        [JsonProperty("description_source")]
        public string DescriptionSource { get; set; }
        public string Franchise { get; set; }
        [JsonProperty("favoured")]
        public bool? IsFavoured { get; set; }
        [JsonProperty("anons")]
        public bool? IsAnons { get; set; }
        [JsonProperty("ongoing")]
        public bool? IsOngoing { get; set; }
        [JsonProperty("thread_id")]
        public int? ThreadId { get; set; }
        [JsonProperty("topic_id")]
        public int? TopicId { get; set; }
        [JsonProperty("myanimelist_id")]
        public int? MyanimelistId { get; set; }
        [JsonProperty("rates_scores_stats")]
        public UserValue[] RatesScoreStats { get; set; }
        [JsonProperty("rates_statuses_stats")]
        public UserValue[] RatesStatusesStats { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonProperty("next_episode_at")]
        public DateTime? NextEpisodeAt { get; set; }
        public Genre[] Genres { get; set; }
        public Studio[] Studios { get; set; }
        public AnimeVideo[] Videos { get; set; }
        public TitleScreenshot[] Screenshots { get; set; }
        [JsonProperty("user_rate")]
        public UserListItem UserRate { get; set; }
    }
}