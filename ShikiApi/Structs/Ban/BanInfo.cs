using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class BanInfo
    {
        public int Id { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        public Comment CommentBan { get; set; }
        [JsonProperty("moderator_id")]
        public int ModeratorId { get; set; }
        public string Reason { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("duration_minutes")]
        public int DurationInMinutes { get; set; }
        public User User { get; set; }
        public User Moderator { get; set; }
    }
}