using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeKindRequest
    {
        [EnumMember(Value = "tv")]
        TV = AnimeKind.TV,
        [EnumMember(Value = "movie")]
        Movie = AnimeKind.Movie,
        [EnumMember(Value = "ova")]
        Ova = AnimeKind.Ova,
        [EnumMember(Value = "ona")]
        Ona = AnimeKind.Ona,
        [EnumMember(Value = "special")]
        Special = AnimeKind.Special,
        [EnumMember(Value = "music")]
        Music = AnimeKind.Music,
        [EnumMember(Value = "tv_13")]
        TV13,
        [EnumMember(Value = "tv_24")]
        TV24,
        [EnumMember(Value = "tv_48")]
        TV48
    }
}