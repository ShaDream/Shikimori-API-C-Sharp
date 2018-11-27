using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class ExternalLink
    {
        public int? Id { get; set; }
        public string Kind { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        [JsonProperty("entry_id")]
        public int EntryId { get; set; }
        [JsonProperty("entry_type")]
        public TypeOfTitle EntryType { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonProperty("imported_at")]
        public DateTime? ImportedAt { get; set; }

    }
}