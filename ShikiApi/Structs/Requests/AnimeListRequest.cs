using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class AnimeListRequest : TitleListRequest
    {
        [Request(Name = "kind")]
        public AnimeKindPicker Kind { get; set; } = null;
        [Request(Name = "duration")]
        public AnimeDuration? Duration { get; set; } = null;
        [Request(Name = "genre")]
        public GenersPicker Genre { get; set; } = null;
        [Request(Name = "studio")]
        public StudioPicker Studio { get; set; } = null;
    }
}