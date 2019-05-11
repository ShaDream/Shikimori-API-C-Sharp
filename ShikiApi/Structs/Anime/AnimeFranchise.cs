using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeFranchise
    {
        public AnimeFranchiseLink[] Links { get; set; }
        public AnimeFranchiseNode[] Nodes { get; set; }
        [JsonProperty("current_id")]
        public int CurrentId { get; set; }
    }
}