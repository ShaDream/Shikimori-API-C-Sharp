using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeSeriesVideoLanguage
    {
        [EnumMember(Value = "russian")]
        Russian,
        [EnumMember(Value = "english")]
        English,
        [EnumMember(Value = "original")]
        Original,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}