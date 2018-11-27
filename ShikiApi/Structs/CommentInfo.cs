using Newtonsoft.Json;

namespace ShikiApi
{
    public class CommentInfo : Comment
    {
        [JsonProperty("html_body")]
        public string HTMLBody { get; set; }
        [JsonProperty("html_bocan_be_editeddy")]
        public bool CanBeEdited { get; set; }
        public User User { get; set; }
    }
}