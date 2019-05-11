using System;
using System.Collections.Generic;
using System.Linq;

namespace ShikiApi
{
    public static class FranchiseNodesToAnimesExtension
    {
        public static IEnumerable<Anime> ToAnime(this IEnumerable<AnimeFranchiseNode> nodes, Shikimori shiki)
        {
            var result = new List<Anime>();
            var pages = (int)Math.Ceiling((float)nodes.Count() / 50) + 1;
            var ids = new IdsPicker(nodes.Select(x => x.Id));

            for (var i = 1; i < pages; i++)
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
    }
}