using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikiApi;

namespace ShikiApi_Tests
{
    [TestClass]
    public class ShikiMethodTests
    {
        static Shikimori shiki = ShikiApiAuthorizationTests.GetShikiFromFile();

        [TestMethod]
        public void GetUserRates()
        {
            var result = shiki.GetUserRates(new UserListItemRequest { UserID = shiki.Info.ID });
        }

        [TestMethod]
        public void GetUserRateById()
        {
            var rates = shiki.GetUserRates(new UserListItemRequest{UserID = shiki.Info.ID });
            var result = shiki.GetUserRateById(rates.First().ID);
        }

        [TestMethod]
        public void IncrementUserRate()
        {
            var rates = shiki.GetUserRates(new UserListItemRequest { UserID = shiki.Info.ID });
            var result = shiki.IncrementUserRate(rates.First().ID);
        }

        [TestMethod]
        public void CreateUserRate()
        {
            //TODO:Create test
            
        }

        [TestMethod]
        public void UpdateUserRate()
        {
            var userRate = shiki.GetUserRates(new UserListItemRequest { UserID = shiki.Info.ID }).First();
            var result = shiki.UpdateUserRate(userRate.ID, userRate);
        }

        [TestMethod]
        public void DeleteUserRate()
        {
            //TODO:Create test
        }

        [TestMethod]
        public void GetStudios()
        {
            var result = shiki.GetStudiosList();
        }

        [TestMethod]
        public void GetGenres()
        {
            var result = shiki.GetGenersList();
        }

        [TestMethod]
        public void GetAnimeList()
        {
            var result = shiki.GetAnimes(new AnimeListRequest(){Limit = 50});
        }

        [TestMethod]
        public void GetAnimeById()
        {
            var result = shiki.GetAnimeById(33095);
        }

        [TestMethod]
        public void GetSimilarAnimes()
        {
            var result = shiki.GetSimilarAnimes(37450);
        }

        [TestMethod]
        public void GetRolesByAnimeId()
        {
            var result = shiki.GetRolesByAnimeId(37450);
        }

        [TestMethod]
        public void GetAnimeRelatedTitles()
        {
            var result = shiki.GetAnimeRelatedTitles(37450);
        }

        [TestMethod]
        public void GetAnimeImage()
        {
            var result = shiki.GetAnimeScreenshots(37450);
        }

        [TestMethod]
        public void GetAnimeExternalsLinks()
        {
            var result = shiki.GetAnimeExternalsLinks(37450);
        }

        [TestMethod]
        public void GetBans()
        {
            var result = shiki.GetBans();
        }

        [TestMethod]
        public void GetCalendar()
        {
            var result = shiki.GetCalendarInfos();
        }

        [TestMethod]
        public void GetCharacterById()
        {
            var result = shiki.GetCharacterById();
        }

        [TestMethod]
        public void GetClub()
        {
            var result = shiki.GetClub(72);
        }

        [TestMethod]
        public void GetClubs()
        {
            var result = shiki.GetClubList(new SearchRequest(){Limit = 30});
        }

        [TestMethod]
        public void GetRanobe()
        {
            var result = shiki.GetRanobe(70399);
        }

        [TestMethod]
        public void GetClubRanobes()
        {
            var result = shiki.GetClubRanobes(912);
        }
    }
}
