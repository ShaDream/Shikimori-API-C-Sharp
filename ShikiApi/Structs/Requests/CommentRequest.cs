using System;

namespace ShikiApi
{
    public class CommentRequest:Request
    {
        [Request(Name = "commentable_id", DefaultValue = 0, IsRequired = true)]
        public int CommentableId { get; set; } = 0;
        [Request(Name = "commentable_type", IsRequired = true)]
        public CommentableType CommentableType { get; set; }
        [Request(Name = "page", DefaultValue = 0)]
        public int Page { get; set; } = 0;
        [Request(Name = "limit", DefaultValue = 0)]
        public int Limit { get; set; } = 0;
        [Request(Name = "desc", DefaultValue = -1)]
        public int Desc { get; set; } = -1;
    }
}