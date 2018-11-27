using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum AnimeVideoKind
    {
        [EnumMember(Value = "pv")]
        PV,
        [EnumMember(Value = "op")]
        OP,
        [EnumMember(Value = "ed")]
        ED
    }
}