using System.Collections.Generic;

namespace ShikiApi
{
    public class ClubUpdateRequest : Request
    {
        [String("name")]
        public string Name { get; set; }
        [String("description")]
        public string Description { get; set; }
        [String("display_images")]
        public bool? DisplayImages { get; set; }
        [String("comment_policy")]
        public ClubCommentPolicy? CommentPolicy { get; set; }
        [String("topic_policy")]
        public ClubPolicy? TopicPolicy { get; set; }
        [String("image_upload_policy")]
        public ClubPolicy? ImageUploadPolicy { get; set; }
    }
}