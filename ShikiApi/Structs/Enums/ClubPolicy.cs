using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum ClubPolicy
    {
        [EnumMember(Value = "members")]
        Members,
        [EnumMember(Value = "admins")]
        Admins
    }
}