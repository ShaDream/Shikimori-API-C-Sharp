using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum ListOrder
    {
        [EnumMember(Value = "id")]
        Id,
        [EnumMember(Value = "ranked")]
        Ranked,
        [EnumMember(Value = "kind")]
        Kind,
        [EnumMember(Value = "popularity")]
        Popularity,
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "aired_on")]
        AiredOn,
        [EnumMember(Value = "episodes")]
        Episodes,
        [EnumMember(Value = "status")]
        Status,
        [EnumMember(Value = "random")]
        Random
    }
}