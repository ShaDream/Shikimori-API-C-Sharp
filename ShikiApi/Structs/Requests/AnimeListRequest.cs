using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeListRequest : Request
    {
        [Request(DefaultValue = 0, Name = "page")]
        public int Page { get; set; } = 0;
        [Request(DefaultValue = 0, Name = "limit")]
        public int Limit { get; set; } = 0;
        [Request(Name = "order")]
        public AnimeOrder? Order { get; set; } = null;
        [Request(Name = "kind")]
        public AnimeKindPicker Kind { get; set; } = null;
        [Request(Name = "status")]
        public TitleStatus? Status { get; set; } = null;
        [Request(Name = "season")]
        public SeasonPicker Season { get; set; } = null;
        [Request(DefaultValue = 0, Name = "score")]
        public int Score { get; set; } = 0;
        [Request(Name = "duration")]
        public AnimeDuration? Duration { get; set; } = null;
        [Request(Name = "genre")]
        public GenersPicker Genre { get; set; } = null;
        [Request(Name = "studio")]
        public StudioPicker Studio { get; set; } = null;
        [Request(DefaultValue = true, Name = "censored")]
        public bool Censored { get; set; } = true;
        [Request(Name = "mylist")]
        public UserItemStatus? MyList { get; set; } = null;
        [Request(Name = "ids")]
        public IdsPicker Ids { get; set; } = null;
        [JsonProperty("exclude_ids")]
        [Request(Name = "exclude_ids")]
        public IdsPicker ExcludeIds { get; set; } = null;
        [Request(Name = "search")]
        public string Search { get; set; } = null;
    }
}