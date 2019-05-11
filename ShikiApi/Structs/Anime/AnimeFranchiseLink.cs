using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeFranchiseLink
    {
        public int Id { get; set; }
        [JsonProperty("source_id")]
        public int SourceId { get; set; }
        [JsonProperty("target_id")]
        public int TargetId { get; set; }
        public int Source { get; set; }
        public int Target { get; set; }
        public int Weight { get; set; }
        public string Relation { get; set; }
    }
}