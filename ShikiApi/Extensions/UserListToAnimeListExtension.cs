using System;
using System.Collections.Generic;
using System.Linq;

namespace ShikiApi
{
    public static class UserListToAnimeListExtension
    {
        public static IEnumerable<Anime> ToAnime(this IEnumerable<UserListItem> list, Shikimori shiki)
        {
            var result = new List<Anime>();
            var pages = (int)Math.Ceiling((float)list.Count() / 50) + 1;
            var ids = new IdsPicker(list.Select(x => x.TargetId));

            for (int i = 1; i < pages; i++)
            {
                result.AddRange(shiki.GetAnimes(new AnimeListRequest
                {
                    Ids = ids,
                    Limit = 50,
                    Page = i
                }));
            }

            return result;
        }

        public static Anime[] ToAnime(this UserListItem[] array, Shikimori shiki)
        {
            var result = new List<Anime>();
            var pages = (int)Math.Ceiling((float)array.Length / 50) + 1;
            var ids = new IdsPicker(array.Select(x => x.TargetId));

            for (int i = 1; i < pages; i++)
            {
                result.AddRange(shiki.GetAnimes(new AnimeListRequest
                {
                    Ids = ids,
                    Limit = 50,
                    Page = i
                }));
            }

            return result.ToArray();
        }
    }
}