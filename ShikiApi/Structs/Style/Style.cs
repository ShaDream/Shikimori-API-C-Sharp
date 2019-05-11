using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class Style : StyleUpdateRequest
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("owner_id")]
        public int? OwnerId { get; set; }

        [JsonProperty("owner_type")]
        public StyleOwnerType OwnerType { get; set; }

        [JsonProperty("compiled_css")]
        public string CompiledCss { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}