using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AbuseRequestKind
    {
        [EnumMember(Value = "offtopic")]
        Offtopic,
        [EnumMember(Value = "summary")]
        Summary,
        [EnumMember(Value = "abuse")]
        Abuse,
        [EnumMember(Value = "spoiler")]
        Spoiler
    }
}