using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeFranchiseNode
    {
        public int Id { get; set; }
        public long? Date { get; set; }
        public string Name { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public int? Year { get; set; }
        public string Kind { get; set; }
        public int Weight { get; set; }
    }
}