using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserInfoStats
    {
        [JsonProperty("statuses")]
        public UserInfoStatuses Statuses { get; set; }

        [JsonProperty("full_statuses")]
        public UserInfoStatuses FullStatuses { get; set; }

        [JsonProperty("scores")]
        public UserInfoValues Scores { get; set; }

        [JsonProperty("types")]
        public UserInfoValues Types { get; set; }

        [JsonProperty("ratings")]
        public UserInfoValues Ratings { get; set; }

        [JsonProperty("has_anime?")]
        public bool HasAnime { get; set; }

        [JsonProperty("has_manga?")]
        public bool HasManga { get; set; }

        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty("studios")]
        public Studio[] Studios { get; set; }

        [JsonProperty("publishers")]
        public Publisher[] Publishers { get; set; }

        [JsonProperty("style_id")]
        public int StyleId { get; set; }
    }
}