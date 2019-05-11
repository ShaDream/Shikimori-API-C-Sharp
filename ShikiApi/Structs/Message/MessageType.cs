using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum MessageType
    {
        [EnumMember(Value = "news")]
        News,
        [EnumMember(Value = "notifications")]
        Notifications
    }
}