using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class Comment
    {
        public int Id { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("commentable_id")]
        public int CommentableId { get; set; }
        [JsonProperty("commentable_type")]
        public string CommentableType { get; set; }
        public string Body { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonProperty("is_summary")]
        public bool IsSummary { get; set; }
        [JsonProperty("is_offtopic")]
        public bool IsOfftopic { get; set; }
    }
}