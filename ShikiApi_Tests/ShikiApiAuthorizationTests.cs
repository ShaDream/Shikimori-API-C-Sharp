using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikiApi;

namespace ShikiApi_Tests
{
    [TestClass]
    public class ShikiApiAuthorizationTests
    {
        [TestMethod]
        public void ThroughAuthorizationCode()
        {
            var shiki = new Shikimori(UserData.authorization,
                                      new ShikiApplication(UserData.appId,
                                                           UserData.secret,
                                                           UserData.name));
            shiki.Save(Directory.GetCurrentDirectory());
        }
    }
}