using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum TopicType
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "offtopic")]
        Offtopic,
        [EnumMember(Value = "animanga")]
        Animanga,
        [EnumMember(Value = "site")]
        Site,
        [EnumMember(Value = "games")]
        Games,
        [EnumMember(Value = "vn")]
        Vn,
        [EnumMember(Value = "contests")]
        Contests,
        [EnumMember(Value = "clubs")]
        Clubs,
        [EnumMember(Value = "my_clubs")]
        MyClubs,
        [EnumMember(Value = "reviews")]
        Reviews,
        [EnumMember(Value = "news")]
        News,
        [EnumMember(Value = "collections")]
        Collections,
        [EnumMember(Value = "cosplay")]
        Cosplay
    }
}