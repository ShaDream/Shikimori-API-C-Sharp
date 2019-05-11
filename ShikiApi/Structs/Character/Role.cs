using Newtonsoft.Json;

namespace ShikiApi
{
    public class Role
    {
        public string[] Roles { get; set; }
        [JsonProperty("roles_russian")]
        public string[] RolesRussian { get; set; }
        public Character Character { get; set; }
        public Character Person { get; set; }
    }
}