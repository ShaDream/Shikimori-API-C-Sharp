using Newtonsoft.Json;

namespace ShikiApi
{
    public class MangaInfo : Manga
    {
        public string[] English { get; set; }
        public string[] Japanese { get; set; }
        public string[] Synonyms { get; set; }
        public float Score { get; set; }
        public string Descriptoion { get; set; }
        [JsonProperty("description_html")]
        public string DescriptionHTML { get; set; }
        [JsonProperty("description_source")]
        public string DescriptionSource { get; set; }
        public bool Favorite { get; set; }
        [JsonProperty("thread_id")]
        public int ThreadId { get; set; }
        [JsonProperty("topic_id")]
        public int TopicId { get; set; }
        [JsonProperty("franchise")]
        public string Franchise { get; set; }
        [JsonProperty("favoured")]
        public bool IsFavoured { get; set; }
        [JsonProperty("anons")]
        public bool IsAnonsed { get; set; }
        [JsonProperty("ongoing")]
        public bool IsOngoing { get; set; }
        [JsonProperty("myanimelist_id")]
        public int MyAnimeListId { get; set; }
        [JsonProperty("rates_scores_stats")]
        public UserValue[] RatesScoreStats { get; set; }
        [JsonProperty("rates_statuses_stats")]
        public UserValue[] RatesStatusesStats { get; set; }
        public Genre[] Genres { get; set; }
        public Publisher[] Publishers { get; set; }
        [JsonProperty("user_rate")]
        public UserListItem UserRate { get; set; }
    }
}