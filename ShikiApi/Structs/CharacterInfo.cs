using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class CharacterInfo : Character
    {
        [JsonProperty("altname")]
        public string AlternativeName { get; set; }
        public string Japanese { get; set; }
        public string Description { get; set; }
        [JsonProperty("description_html")]
        public string DescriptionHTML { get; set; }
        public string DescriptionSource { get; set; }
        public bool Favoured { get; set; }
        [JsonProperty("thread_id")]
        public int ThreadId { get; set; }
        public int TopicId { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        public Seyu[] Seyu { get; set; }
        public AnimeRole[] Animes { get; set; }
        public MangaRole[] Mangas { get; set; }
    }
}