using System.Runtime.Serialization;

namespace ShikiApi
{
    public enum MangaKind
    {
        [EnumMember(Value = "manga")]
        Manga,
        [EnumMember(Value = "manhwa")]
        Manhwa,
        [EnumMember(Value = "manhua")]
        Manhua,
        [EnumMember(Value = "novel")]
        Novel,
        [EnumMember(Value = "one_shot")]
        OneShot,
        [EnumMember(Value = "doujin")]
        Doujin
    }
}