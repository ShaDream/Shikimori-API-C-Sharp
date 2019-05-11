namespace ShikiApi
{
    public class StyleUpdateRequest : Request
    {
        [Request(IsRequired = false, Name = "name")]
        public string Name { get; set; }

        [Request(IsRequired = false, Name = "css")]
        public string Css { get; set; }
    }
}