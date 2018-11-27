using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikiApi;

namespace ShikiApi_Tests
{
    [TestClass]
    public class ShikiApiAuthorizationTests
    {
        public static Shikimori GetShikiFromFile()
        {
            long expiresAt;
            string refreshToken;
            string accessToken;
            string authorizationCode;
            string appId;
            string appSecret;
            using (var reader = new StreamReader("C:\\Users\\ShaDream\\source\\repos\\ShikiApi\\ShikiApi_Tests\\bin\\Debug\\Settings.txt", Encoding.Default))
            {
                expiresAt = long.Parse(reader.ReadLine());
                refreshToken = reader.ReadLine();
                accessToken = reader.ReadLine();
                authorizationCode = reader.ReadLine();
                appId = reader.ReadLine();
                appSecret = reader.ReadLine();

            }
            return new Shikimori(expiresAt, refreshToken, accessToken,
                authorizationCode, new ShikiApplication(appId, appSecret, "TrackerApp"));
        }

        [TestMethod]
        public void Authorize()
        {
            GetShikiFromFile();
        }

    }
}
