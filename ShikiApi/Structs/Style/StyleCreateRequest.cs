namespace ShikiApi
{
    public class StyleCreateRequest : Request
    {
        [Request(IsRequired = true, Name = "owner_id")]
        public int? OwnerId { get; set; }

        [Request(IsRequired = true, Name = "owner_type")]
        public StyleOwnerType OwnerType { get; set; }

        [Request(IsRequired = true, Name = "name")]
        public string Name { get; set; }

        [Request(IsRequired = true, Name = "css")]
        public string Css { get; set; }
    }
}