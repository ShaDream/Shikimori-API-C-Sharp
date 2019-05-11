using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class Message
    {
        public int Id { get; set; }
        public MessagePrivacyType Kind { get; set; }
        [JsonProperty("read")]
        public bool Readed { get; set; }
        public string Body { get; set; }
        [JsonProperty("html_body")]
        public string BodyHtml { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        public bool? Linked { get; set; }
        public User From { get; set; }
        public User To { get; set; }
    }
}