namespace ShikiApi
{
    public class ShikiApplication
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }

        public ShikiApplication(string id, string secret, string name)
        {
            Id = id;
            Secret = secret;
            Name = name;
        }
    }
}