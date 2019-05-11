using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class Achievements
    {
        public int ID { get; set; }
        [JsonProperty("neko_id")]
        public string NekoId { get; set; }
        public int Level { get; set; }
        public int Progress { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}