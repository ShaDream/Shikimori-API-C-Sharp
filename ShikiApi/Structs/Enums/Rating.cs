using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum Rating
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "g")]
        G,
        [EnumMember(Value = "pg")]
        PG,
        [EnumMember(Value = "pg_13")]
        PG13,
        [EnumMember(Value = "r")]
        R,
        [EnumMember(Value = "r_plus")]
        RPlus,
        [EnumMember(Value = "rx")]
        RX
    }
}