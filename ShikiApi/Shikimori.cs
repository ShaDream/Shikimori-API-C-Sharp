using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikiApi.JSONWriter;
using static ShikiApi.ShikiQuery;

namespace ShikiApi
{
    public class Shikimori
    {
        #region private Members

        private const string Domain = "https://shikimori.org/";
        private User _userInfo;
        private string _accessToken;
        private long _timeToExpired = long.MaxValue;

        #endregion

        #region Private Properties

        private string authorizationCode { get; set; }
        private string refreshToken { get; set; }

        private long timeToExpired
        {
            get => _timeToExpired;
            set
            {
                if (value < DateTime.UtcNow.ToUnixTime())
                {
                    GetAccessTokenFromRefreshToken(refreshToken);
                    SaveToFile("C:\\Users\\ShaDream\\source\\repos\\ShikiApi\\ShikiApi_Tests\\bin\\Debug\\Settings.txt");
                }
                else
                    _timeToExpired = value;
            }
        }

        #endregion

        #region Public Properties

        public string AccessToken
        {
            get
            {
                if (DateTime.UtcNow.ToUnixTime() > timeToExpired)
                    GetAccessTokenFromRefreshToken(refreshToken);
                return _accessToken;
            }
            private set => _accessToken = value;
        }


        public string UserId { get; set; }

        public ShikiApplication Application { get; private set; }
        public User Info => _userInfo ?? GetUserInfo();

        #endregion

        #region Constructors

        public Shikimori(string authorizationCode, ShikiApplication app)
        {
            this.authorizationCode = authorizationCode;
            Application = app;

            GetAccessToken();
        }

        public Shikimori(long expiredDate, string refreshToken, string accessToken, string authorizationCode, ShikiApplication app)
        {
            this.authorizationCode = authorizationCode;
            Application = app;

            this.refreshToken = refreshToken;
            this.AccessToken = accessToken;
            timeToExpired = expiredDate;
        }

        #endregion

        #region Methods

        private User GetUserInfo() => GET<User>("https://shikimori.org/" + "/api/users/whoami", this);

        #region Token Methods

        private bool IsExpired(long expiredDate) => expiredDate <= DateTime.UtcNow.ToUnixTime();

        private void GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "TrackerApp");

                var dataContent = new MultipartFormDataContent
                {
                    {"authorization_code".ToByteArrayContent(), "grant_type"},
                    {Application.Id.ToByteArrayContent(), "client_id"},
                    {Application.Secret.ToByteArrayContent(), "client_secret"},
                    {authorizationCode.ToByteArrayContent(), "code"},
                    {"https://shikimori.org/".ToByteArrayContent(),"redirect_uri" }
                };

                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(client
                    .PostAsync("https://shikimori.org/oauth/token", dataContent).Result.Content.ReadAsStringAsync()
                    .Result);

                if (result.ContainsKey("error") && result["error"] == "invalid_grant")
                {
                    throw new Exception(
                        "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client");
                }

                AccessToken = result["access_token"];
                refreshToken = result["refresh_token"];
                timeToExpired = (long.Parse(result["created_at"]) + 86400);
            }
        }

        private void GetAccessTokenFromRefreshToken(string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", Application.Name);

                var jsonData = new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("grant_type","refresh_token"),
                    new KeyValuePair<string, string>("client_id",Application.Id),
                    new KeyValuePair<string, string>("client_secret",Application.Secret),
                    new KeyValuePair<string, string>("refresh_token",token),
                }.ConvertToJsonString();

                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(client
                    .PostAsync("https://shikimori.org/oauth/token",
                        new StringContent(jsonData, Encoding.UTF8, "application/json")).Result.Content
                    .ReadAsStringAsync()
                    .Result);

                if (result.ContainsKey("error") && result["error"] == "invalid_grant")
                {
                    throw new Exception(
                        "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client");
                }

                AccessToken = result["access_token"];
                refreshToken = result["refresh_token"];
                timeToExpired = (long.Parse(result["created_at"]) + long.Parse(result["expires_in"]));
            }
        }

        #endregion

        #region UserRate Methods

        public UserListItem IncrementUserRate(int id)
        {
            return POST<UserListItem>(Domain + $"api/v2/user_rates/{id}/increment ", this);
        }

        public UserListItem GetUserRateById(int id)
        {
            return GET<UserListItem>(Domain + $"api/v2/user_rates/{id}", this);
        }

        public List<UserListItem> GetUserRates(UserListItemRequest request)
        {
            return GET<List<UserListItem>>(Domain + "api/v2/user_rates", this, request.ToKeyValuePairs());
        }

        public void CreateUserRate(UserListItem rate)
        {
            var content = new StringContent(rate.ConvertToJsonString(), Encoding.UTF8, "application/json");
            POST<UserListItem>(Domain + "api/v2/user_rates", content, this);
        }

        public UserListItem UpdateUserRate(int id, UserListItem rate)
        {
            var content = new StringContent(rate.ConvertToJsonString(), Encoding.UTF8, "application/json");
            return PUT<UserListItem>(Domain + $"api/v2/user_rates/{id}", this, content);
        }

        public HttpStatusCode DeleteUserRate(int id)
        {
            return DELETE(Domain + $"api/v2/user_rates/{id}", this);
        }

        #endregion

        #region AbuseRequests Methods

        public AbuseRequest MarkCommentOfftopic(int commentId)
        {
            var parametr = new KeyValuePair<string, string>("comment_id", commentId.ToString());
            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/offtopic",
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { parametr }), this);
        }

        public AbuseRequest MarkCommentSummary(int commentId)
        {
            var parametr = new KeyValuePair<string, string>("comment_id", commentId.ToString());
            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/summary",
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { parametr }), this);
        }

        public AbuseRequest CreateAbuseViolationRules(int commentId, string reason)
        {
            var parametrs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("comment_id", commentId.ToString()),
                new KeyValuePair<string, string>("reason",reason)
            };

            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/abuse",
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { parametrs[0], parametrs[1] }), this);
        }

        public AbuseRequest CreateAbuseSpoilerContent(int commentId, string reason)
        {
            var parametrs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("comment_id", commentId.ToString()),
                new KeyValuePair<string, string>("reason",reason)
            };

            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/spoiler",
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { parametrs[0], parametrs[1] }), this);
        }

        #endregion

        #region IgnoreMethods

        public IgnoreResponse UserIgnore(int userId)
        {
            return POST<IgnoreResponse>(Domain + $"api/v2/users/{userId}/ignore", this);
        }

        public HttpStatusCode UserUnignore(int userId)
        {
            return DELETE(Domain + $"api/v2/users/{userId}/ignore", this);
        }

        #endregion

        #region Topic Ignore Methods

        public TopicIgnoreResponse IgnoreTopic(int topicId)
        {
            return POST<TopicIgnoreResponse>(Domain + $"api/v2/topics/{topicId}/ignore", this);
        }

        public HttpStatusCode UnignoreTopic(int topicId)
        {
            return DELETE(Domain + $"api/v2/topics/{topicId}/ignore");
        }

        #endregion

        #region Achivments Methods

        //TODO: Waiting for release

        #endregion

        #region Anime Videos Methods

        public AnimeSeriesVideoResponse CreateAnimeEpisode(int animeId, AnimeSeriesVideo seriesVideo)
        {
            var content = new StringContent(seriesVideo.ConvertToJsonString(), Encoding.UTF8, "application/json");
            return POST<AnimeSeriesVideoResponse>(Domain + $"api/animes/{animeId}/anime_videos", content, this);
        }

        #endregion

        #region Anime Methods

        public List<Anime> GetAnimes(AnimeListRequest request)
        {
            return GET<List<Anime>>(Domain + "api/animes", this, request.ToKeyValuePairs());
        }

        public AnimeInfo GetAnimeById(int id)
        {
            return GET<AnimeInfo>(Domain + $"api/animes/{id}", this);
        }

        public List<Role> GetRolesByAnimeId(int id)
        {
            return GET<List<Role>>(Domain + $"api/animes/{id}/roles", this);
        }

        public List<Anime> GetSimilarAnimes(int id)
        {
            return GET<List<Anime>>(Domain + $"api/animes/{id}/similar", this);
        }

        public List<RelatedTitle> GetAnimeRelatedTitles(int id)
        {
            return GET<List<RelatedTitle>>(Domain + $"api/animes/{id}/related", this);
        }

        public List<TitleScreenshot> GetAnimeScreenshots(int id)
        {
            return GET<List<TitleScreenshot>>(Domain + $"api/animes/{id}/screenshots", this);
        }

        public List<ExternalLink> GetAnimeExternalsLinks(int id)
        {
            return GET<List<ExternalLink>>(Domain + $"api/animes/{id}/external_links", this);
        }

        //TODO: Maybe some franchise added

        #endregion

        #region Appear Methods

        //TODO:DO IT

        #endregion

        #region Bans Methods

        public List<BanInfo> GetBans()
        {
            return GET<List<BanInfo>>(Domain + "api/bans", this);
        }

        #endregion

        #region Geners Methods

        public List<Genre> GetGenersList()
        {
            return GET<List<Genre>>(Domain + "api/genres", this);
        }

        #endregion

        #region Studio Methods

        public List<Studio> GetStudiosList()
        {
            return GET<List<Studio>>(Domain + "api/studios", this);
        }

        #endregion

        #region CalendarMethods

        public List<CalendarInfo> GetCalendarInfos()
        {
            return GET<List<CalendarInfo>>(Domain + "api/calendar", this);
        }

        #endregion

        #region Character Methods

        public CharacterInfo GetCharacterById()
        {
            return GET<CharacterInfo>(Domain + "api/characters/118739", this);
        }

        //TODO: Search not enough info

        #endregion

        #region Club Methods

        public ClubInfo GetClub(int id)
        {
            return GET<ClubInfo>(Domain + $"api/clubs/{id}", this);
        }

        public List<Club> GetClubList(SearchRequest request)
        {
            return GET<List<Club>>(Domain + "api/clubs", this, request.ToKeyValuePairs());
        }

        public ClubInfo UpdateClubSettings(ClubUpdateRequest request, int id)
        {
            return PUT<ClubInfo>(Domain + $"api/clubs/{id}", this, request.ToKeyValuePairs());
        }

        public List<Anime> GetClubAnime(int id)
        {
            return GET<List<Anime>>(Domain + $"api/clubs/{id}/animes", this);
        }

        public List<Manga> GetClubRanobes(int id)
        {
            return GET<List<Manga>>(Domain + $"api/clubs/{id}/ranobe", this);
        }

        public List<Character> GetClubCharacters(int id)
        {
            return GET<List<Character>>(Domain + $"api/clubs/{id}/characters", this);
        }

        public List<User> GetClubMembers(int id)
        {
            return GET<List<User>>(Domain + $"api/clubs/{id}/members", this);
        }

        public List<ClubImage> GetClubImages(int id)
        {
            return GET<List<ClubImage>>(Domain + $"api/clubs/{id}/images", this);
        }

        public void JoinClub(int id)
        {
            POST<string>(Domain + $"api/clubs/{id}/join", this);
        }

        public void LeaveClub(int id)
        {
            POST<string>(Domain + $"api/clubs/{id}/leave", this);
        }

        #endregion

        #region Comment Methods

        public CommentInfo GetComment(int id)
        {
            return GET<CommentInfo>(Domain + $"api/comments/{id}", this);
        }



        #endregion

        #region Ranobe Methods

        public MangaInfo GetRanobe(int id)
        {
            return GET<MangaInfo>(Domain + $"api/ranobe/{id}", this);
        }

        #endregion

        /// <summary>
        /// Save Shikimori access token, refresh token, expired date, application id and application secret
        /// </summary>
        /// <param name="path">PathToSaveShikiData</param>
        private void SaveToFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(timeToExpired);
                writer.WriteLine(refreshToken);
                writer.WriteLine(AccessToken);
                writer.WriteLine(authorizationCode);
                writer.WriteLine(Application.Id);
                writer.WriteLine(Application.Secret);
            }
        }

        #endregion
    }
}
