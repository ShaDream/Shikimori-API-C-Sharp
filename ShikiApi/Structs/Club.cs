using Newtonsoft.Json;

namespace ShikiApi
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClubLogo Logo { get; set; }
        [JsonProperty("is_censored")]
        public bool IsCensored { get; set; }
        [JsonProperty("join_policy")]
        public ClubJoinPolicy JoinPolicy { get; set; }
        [JsonProperty("comment_policy")]
        public ClubCommentPolicy CommentPolicy { get; set; }
    }
}