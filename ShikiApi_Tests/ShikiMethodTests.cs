using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikiApi;

namespace ShikiApi_Tests
{
    [TestClass]
    public class ShikiMethodTests
    {
        static Shikimori shiki = Shikimori.Load(Directory.GetCurrentDirectory());

        [TestMethod]
        public void GetUserRates()
        {
            var result = shiki.GetUserRates(new UserListItemRequest { UserId = shiki.Info.ID });
        }

        [TestMethod]
        public void GetUserRateById()
        {
            var rates = shiki.GetUserRates(new UserListItemRequest{UserId = shiki.Info.ID, TargetType = TypeOfTitle.Anime});
            var result = shiki.GetUserRateById(rates.First().Id);
        }

        [TestMethod]
        public void IncrementUserRate()
        {
            var rates = shiki.GetUserRates(new UserListItemRequest { UserId = shiki.Info.ID });
            var result = shiki.IncrementUserRate(rates.First().Id);
        }

        [TestMethod]
        public void CreateUserRate()
        {
            //TODO:Create test
            
        }

        [TestMethod]
        public void UpdateUserRate()
        {
            var userRate = shiki.GetUserRates(new UserListItemRequest { UserId = shiki.Info.ID }).First();
            var result = shiki.UpdateUserRate(userRate.Id, userRate);
        }

        [TestMethod]
        public void DeleteUserRate()
        {
            //TODO:Create test
        }

        [TestMethod]
        public void GetStudios()
        {
            var result = shiki.GetStudios();
        }

        [TestMethod]
        public void GetGenres()
        {
            var result = shiki.GetGeners();
        }

        [TestMethod]
        public void GetAnimeList()
        {
            var result = shiki.GetAnimes(new AnimeListRequest(){Limit = 30});
        }

        [TestMethod]
        public void GetAnimeById()
        {
            var result = shiki.GetAnimeById(21);
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
            var result = shiki.GetAnimeRelatedTitles(21);
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
            var result = shiki.GetCharacterById(12456);
        }

        [TestMethod]
        public void GetClub()
        {
            var result = shiki.GetClubById(72);
        }

        [TestMethod]
        public void GetClubs()
        {
            var result = shiki.GetClubs(new SearchRequest());
        }

        [TestMethod]
        public void GetRanobe()
        {
            var result = shiki.GetRanobeById(70399);
        }

        [TestMethod]
        public void GetClubRanobes()
        {
            var result = shiki.GetClubRanobes(912);
        }

        [TestMethod]
        public void GetUserById()
        {
            var result = shiki.GetUserById(shiki.Info.ID);
        }

        [TestMethod]
        public void GetPersonById()
        {
            var result = shiki.GetPersonInfo(126);
        }

        [TestMethod]
        public void SearchPerson()
        {
            var result = shiki.SearchPerson(new SearchRequest() {Search = "YUI"});
        }

        [TestMethod]
        public void GetPublishers()
        {
            var result = shiki.GetPublishers();
        }

        [TestMethod]
        public void GetActiveUsers()
        {
            var result = shiki.GetActiveUsers();
        }

        [TestMethod]
        public void GetTopicsList()
        {
            //var result = shiki.GetTopicList(new TopicListRequest() {Limit = 10});
        }

        [TestMethod]
        public void GetFranchise()
        {
             shiki.GetFranchise(18);
        }

        [TestMethod]
        public void GetAchievments()
        {
            var achievments = shiki.GetAchivments(shiki.Info.ID);
            Console.WriteLine(achievments);
        }
    }
}
