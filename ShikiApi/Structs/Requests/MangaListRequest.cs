namespace ShikiApi
{
    public class MangaListRequest : TitleListRequest
    {
        [Request(Name = "publisher")]
        public IdsPicker Publishers { get; set; }
    }
}