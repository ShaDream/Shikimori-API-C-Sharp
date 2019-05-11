namespace ShikiApi
{
    public class MessageCreateRequest : Request
    {
        [Request(DefaultValue = "", IsRequired = true, Name = "body")]
        public string Message { get; set; }

        [Request(DefaultValue = 0, IsRequired = true, Name = "from_id")]
        public int FromId { get; set; }

        [Request(IsRequired = true, Name = "kind")]
        public MessagePrivacyType Kind { get; set; } = MessagePrivacyType.Private;

        [Request(DefaultValue = 0,IsRequired = true, Name = "to_id")]
        public int ToId { get; set; }
    }
}