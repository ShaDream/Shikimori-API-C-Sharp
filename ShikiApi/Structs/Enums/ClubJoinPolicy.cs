using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum ClubJoinPolicy
    {
        Free,
        [EnumMember(Value = "admin_invite")]
        AdminInvite,
        [EnumMember(Value = "owner_invite")]
        OwnerInvite
    }
}