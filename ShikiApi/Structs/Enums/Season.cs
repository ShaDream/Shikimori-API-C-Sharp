using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum Season
    {
        [EnumMember(Value = "spring")]
        Spring,
        [EnumMember(Value = "summer")]
        Summer,
        [EnumMember(Value = "autumn")]
        Autumn,
        [EnumMember(Value = "winter")]
        Winter
    }
}