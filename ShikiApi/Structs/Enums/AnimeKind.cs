using System;
using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeKind
    {
        [EnumMember(Value = "tv")]
        TV,
        [EnumMember(Value = "movie")]
        Movie,
        [EnumMember(Value = "ova")]
        Ova,
        [EnumMember(Value = "ona")]
        Ona,
        [EnumMember(Value = "special")]
        Special,
        [EnumMember(Value = "music")]
        Music
    }
}