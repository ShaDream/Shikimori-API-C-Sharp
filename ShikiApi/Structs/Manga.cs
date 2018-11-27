using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    //Todo: SomeMoreProperties
    public class Manga
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Russian { get; set; }
        public Image Image { get; set; }
        public string Url { get; set; }
        public MangaKind Kind { get; set; }
        public TitleStatus Status { get; set; }
        public int Volumes { get; set; }
        public int Chapters { get; set; }
        [JsonProperty("aired_on")]
        public DateTime? AiredOn { get; set; }
        [JsonProperty("released_on")]
        public DateTime? ReleasedOn { get; set; }
        

    }
}