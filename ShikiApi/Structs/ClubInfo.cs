using Newtonsoft.Json;

namespace ShikiApi
{
    public class ClubInfo : Club
    {
        public string Description { get; set; }
        [JsonProperty("description_html")]
        public string DescriptionHTML { get; set; }
        public Manga[] Mangas { get; set; }
        public Character[] Characters { get; set; }
        [JsonProperty("thread_id")]
        public int ThreadId { get; set; }
        [JsonProperty("topic_id")]
        public int TopicId { get; set; }
        public User[] Members { get; set; }
        public Anime[] Animes { get; set; }
        [JsonProperty("user_role")]
        public ClubUserRole? UserRole { get; set; }
        public ClubImage[] Images { get; set; }
    }
}