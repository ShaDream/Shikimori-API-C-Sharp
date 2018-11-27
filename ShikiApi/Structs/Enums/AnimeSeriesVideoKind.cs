using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeSeriesVideoKind
    {
        [EnumMember(Value = "raw")]
        Raw,
        [EnumMember(Value = "planned")]
        Subtitles,
        [EnumMember(Value = "fandub")]
        Fandub,
        [EnumMember(Value = "unknown")]
        Unknow
    }
}