using System.Collections.Generic;

namespace ShikiApi
{
    public class ClubUpdateRequest : Request
    {
        [Request(Name = "name")]
        public string Name { get; set; }
        [Request(Name = "description")]
        public string Description { get; set; }
        [Request(Name = "display_images")]
        public bool? DisplayImages { get; set; }
        [Request(Name = "comment_policy")]
        public ClubCommentPolicy? CommentPolicy { get; set; }
        [Request(Name = "topic_policy")]
        public ClubPolicy? TopicPolicy { get; set; }
        [Request(Name = "image_upload_policy")]
        public ClubPolicy? ImageUploadPolicy { get; set; }
    }
}