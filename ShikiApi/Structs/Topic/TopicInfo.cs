using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public partial class TopicInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("topic_title")]
        public string TopicTitle { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }

        [JsonProperty("html_footer")]
        public string HtmlFooter { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("forum")]
        public TopicType Forum { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("linked_id")]
        public int? LinkedId { get; set; }

        [JsonProperty("linked_type")]
        public TopicLinkedType LinkedType { get; set; }

        [JsonProperty("linked")]
        public bool Linked { get; set; }

        [JsonProperty("viewed")]
        public bool Viewed { get; set; }

        [JsonProperty("last_comment_viewed")]
        public DateTime? LastCommentViewed { get; set; }
    }
}