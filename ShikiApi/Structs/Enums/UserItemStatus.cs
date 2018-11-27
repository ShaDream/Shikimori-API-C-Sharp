using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ShikiApi
{
    public enum UserItemStatus
    {
        [EnumMember(Value = "planned")]
        Planned,
        [EnumMember(Value = "watching")]
        Wathcing,
        [EnumMember(Value = "rewatching")]
        Rewatching,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "on_hold")]
        OnHold,
        [EnumMember(Value = "dropped")]
        Dropped
    }
}