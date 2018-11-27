using System;
using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum TitleStatus
    {
        [EnumMember(Value = "anons")]
        Anons,
        [EnumMember(Value = "ongoing")]
        Ongoing,
        [EnumMember(Value = "realeased")]
        Released
    }
}