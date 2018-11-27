using Newtonsoft.Json;

namespace ShikiApi
{
    public class RelatedTitle
    {
        public string Relation { get; set; }
        [JsonProperty("relation_russian")]
        public string RelationRussia { get; set; }
        public Anime Anime { get; set; }
        public Manga Manga { get; set; }
    }
}