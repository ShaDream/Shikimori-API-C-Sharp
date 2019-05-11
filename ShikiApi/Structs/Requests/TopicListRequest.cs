using Newtonsoft.Json;

namespace ShikiApi
{
    public class TopicListRequest : BaseListRequest
    {
        [Request(Name = "forum")]
        public TopicType? Forum { get; set; }

        [Request(Name = "linked_id", DefaultValue = 0)]
        public int LinkedId { get; set; }

        [Request(Name = "linked_type")]
        public TopicLinkedType? LinkedType { get; set; }
    }
}