namespace ShikiApi
{
    public class AnimeSeriesVideo
    {
        public int AnimeId { get; set; }
        public string AuthorName { get; set; }
        public int Episode { get; set; }
        public AnimeSeriesVideoKind Kind { get; set; }
        public AnimeSeriesVideoLanguage Language { get; set; }
        public AnimeSeriesVideoQuality Quality { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
    }
}