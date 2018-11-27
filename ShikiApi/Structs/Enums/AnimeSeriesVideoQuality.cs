using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeSeriesVideoQuality
    {
        [EnumMember(Value = "bd")]
        BD,
        [EnumMember(Value = "web")]
        Web,
        [EnumMember(Value = "tv")]
        TV,
        [EnumMember(Value = "dvd")]
        DVD,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}