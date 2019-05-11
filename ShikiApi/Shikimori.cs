using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ShikiApi.JSONWriter;
using static ShikiApi.ShikiQuery;

namespace ShikiApi
{
    public class Shikimori
    {
        #region private Members

        private const string Domain = "https://shikimori.org/";
        private readonly User _userInfo;
        private string _accessToken;
        private long _timeToExpired = long.MaxValue;

        #endregion

        #region Public Properties

        public string authorizationCode { get; set; }
        public string refreshToken { get; set; }

        public long timeToExpired
        {
            get => _timeToExpired;
            private set
            {
                if (value < DateTime.UtcNow.ToUnixTime())
                {
                    GetAccessTokenFromRefreshToken(refreshToken);
#if DEBUG
                    SaveToFile("C:\\Users\\ShaDream\\source\\repos\\ShikiApi\\ShikiApi_Tests\\bin\\Debug\\Settings.txt");
#endif
                }
                else
                    _timeToExpired = value;
            }
        }

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

        public int UserId => Info.ID;

        public ShikiApplication Application { get; private set; }
        public User Info => _userInfo ?? GetUserInfo();

        #endregion

        #region Constructors

        public Shikimori(string authorizationCode, ShikiApplication app)
        {
            this.authorizationCode = authorizationCode;
            Application = app;
            GetAccessToken();

            _userInfo = GetUserInfo();
        }

        public Shikimori(long expiredDate, string refreshToken, string accessToken, string authorizationCode, ShikiApplication app)
        {
            this.authorizationCode = authorizationCode;
            Application = app;

            this.refreshToken = refreshToken;
            AccessToken = accessToken;
            timeToExpired = expiredDate;

            _userInfo = GetUserInfo();
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
                client.DefaultRequestHeaders.Add("User-Agent", Application.Name);

                var jsonData = new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("client_id", Application.Id),
                    new KeyValuePair<string, string>("client_secret", Application.Secret),
                    new KeyValuePair<string, string>("code", authorizationCode),
                    new KeyValuePair<string, string>("redirect_uri", "https://shikimori.org/"),
                }.ConvertToJsonString();

                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(client
                    .PostAsync("https://shikimori.org/oauth/token",
                        new StringContent(jsonData,
                            Encoding.UTF8,
                            "application/json"))
                    .Result.Content.ReadAsStringAsync()
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

                var jsonData = new[]
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

        public IEnumerable<UserListItem> GetUserRates(UserListItemRequest request)
        {
            return GET<IEnumerable<UserListItem>>(Domain + "api/v2/user_rates", this, request.ToKeyValuePairs());
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
            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/offtopic", this, parametr);
        }

        public AbuseRequest MarkCommentSummary(int commentId)
        {
            var parametr = new KeyValuePair<string, string>("comment_id", commentId.ToString());
            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/summary", this, parametr);
        }

        public AbuseRequest CreateAbuseViolationRules(int commentId, string reason)
        {
            var parametrs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("comment_id", commentId.ToString()),
                new KeyValuePair<string, string>("reason",reason)
            };

            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/abuse", this, parametrs);
        }

        public AbuseRequest CreateAbuseSpoilerContent(int commentId, string reason)
        {
            var parametrs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("comment_id", commentId.ToString()),
                new KeyValuePair<string, string>("reason",reason)
            };

            return POST<AbuseRequest>(Domain + "api/v2/abuse_requests/spoiler", this, parametrs);
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

        public IEnumerable<Anime> GetAnimes(AnimeListRequest request)
        {
            return GET<IEnumerable<Anime>>(Domain + "api/animes", this, request.ToKeyValuePairs());
        }

        public AnimeInfo GetAnimeById(int id)
        {
            return GET<AnimeInfo>(Domain + $"api/animes/{id}", this);
        }

        public IEnumerable<Role> GetRolesByAnimeId(int id)
        {
            return GET<IEnumerable<Role>>(Domain + $"api/animes/{id}/roles", this);
        }

        public IEnumerable<Anime> GetSimilarAnimes(int id)
        {
            return GET<IEnumerable<Anime>>(Domain + $"api/animes/{id}/similar", this);
        }

        public IEnumerable<RelatedTitle> GetAnimeRelatedTitles(int id)
        {
            return GET<IEnumerable<RelatedTitle>>(Domain + $"api/animes/{id}/related", this);
        }

        public IEnumerable<TitleScreenshot> GetAnimeScreenshots(int id)
        {
            return GET<IEnumerable<TitleScreenshot>>(Domain + $"api/animes/{id}/screenshots", this);
        }

        public IEnumerable<ExternalLink> GetAnimeExternalsLinks(int id)
        {
            return GET<IEnumerable<ExternalLink>>(Domain + $"api/animes/{id}/external_links", this);
        }

        public AnimeFranchise GetFranchise(int id)
        {
            return GET<AnimeFranchise>(Domain + $"api/animes/{id}/franchise", this);
        }

        #endregion

        #region Appear Methods

        //TODO:DO IT

        #endregion

        #region Bans Methods

        public IEnumerable<BanInfo> GetBans()
        {
            return GET<IEnumerable<BanInfo>>(Domain + "api/bans", this);
        }

        #endregion

        #region Geners Methods

        public IEnumerable<Genre> GetGeners()
        {
            return GET<IEnumerable<Genre>>(Domain + "api/genres", this);
        }

        #endregion

        #region Studio Methods

        public IEnumerable<Studio> GetStudios()
        {
            return GET<IEnumerable<Studio>>(Domain + "api/studios", this);
        }

        #endregion

        #region CalendarMethods

        public IEnumerable<CalendarInfo> GetCalendarInfos()
        {
            return GET<IEnumerable<CalendarInfo>>(Domain + "api/calendar", this);
        }

        #endregion

        #region Character Methods

        public CharacterInfo GetCharacterById(int id)
        {
            return GET<CharacterInfo>(Domain + $"api/characters/{id}", this);
        }

        //TODO: Search not enough info

        #endregion

        #region Club Methods

        public ClubInfo GetClubById(int id)
        {
            return GET<ClubInfo>(Domain + $"api/clubs/{id}", this);
        }

        public IEnumerable<Club> GetClubs(SearchRequest request)
        {
            return GET<IEnumerable<Club>>(Domain + "api/clubs", this, request.ToKeyValuePairs());
        }

        public ClubInfo UpdateClubSettings(ClubUpdateRequest request, int id)
        {
            return PUT<ClubInfo>(Domain + $"api/clubs/{id}", this, request.ToKeyValuePairs());
        }

        public IEnumerable<Anime> GetClubAnime(int id)
        {
            return GET<IEnumerable<Anime>>(Domain + $"api/clubs/{id}/animes", this);
        }

        public IEnumerable<Manga> GetClubRanobes(int id)
        {
            return GET<IEnumerable<Manga>>(Domain + $"api/clubs/{id}/ranobe", this);
        }

        public IEnumerable<Character> GetClubCharacters(int id)
        {
            return GET<IEnumerable<Character>>(Domain + $"api/clubs/{id}/characters", this);
        }

        public IEnumerable<User> GetClubMembers(int id)
        {
            return GET<IEnumerable<User>>(Domain + $"api/clubs/{id}/members", this);
        }

        public IEnumerable<ClubImage> GetClubImages(int id)
        {
            return GET<IEnumerable<ClubImage>>(Domain + $"api/clubs/{id}/images", this);
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

        public CommentInfo GetCommentById(int id)
        {
            return GET<CommentInfo>(Domain + $"api/comments/{id}", this);
        }

        public IEnumerable<CommentInfo> GetComments(CommentRequest request)
        {
            return GET<IEnumerable<CommentInfo>>(Domain + "api/comments", this, request.ToKeyValuePairs());
        }

        public CommentInfo CreateComment(CommentCreationRequest request)
        {
            return POST<CommentInfo>(Domain + "api/comments",
                new StringContent(request.ToKeyValuePairs().ConvertToJsonString()), this);
        }

        public HttpStatusCode DeleteComment(int id)
        {
            return DELETE(Domain + $"api/comments/{id}");
        }

        #endregion

        #region Manga Methods

        public IEnumerable<Manga> GetMangas(MangaListRequest request)
        {
            return GET<IEnumerable<Manga>>(Domain + "api/mangas", this, request.ToKeyValuePairs());
        }

        public MangaInfo GetMangaById(int id)
        {
            return GET<MangaInfo>(Domain + $"api/mangas/{id}", this);
        }

        public IEnumerable<Role> GetMangaRoles(int id)
        {
            return GET<IEnumerable<Role>>(Domain + $"api/mangas/{id}/roles", this);
        }

        public IEnumerable<Manga> GetSimilarMangas(int id)
        {
            return GET<IEnumerable<Manga>>(Domain + $"api/mangas/{id}/similar", this);
        }

        public IEnumerable<RelatedTitle> GetRelatedMangas(int id)
        {
            return GET<IEnumerable<RelatedTitle>>(Domain + $"api/mangas/{id}/related", this);
        }

        public IEnumerable<ExternalLink> GetMangaLinks(int id)
        {
            return GET<IEnumerable<ExternalLink>>(Domain + $"api/mangas/{id}/external_links ", this);
        }

        #endregion

        #region Message Methods

        public Message GetMessage(int id)
        {
            return GET<Message>(Domain + $"api/messages/{id}", this);
        }

        public Message CreateMessage(MessageCreateRequest request)
        {
            var data = new StringContent(request.ToKeyValuePairs().ConvertToJsonString(), Encoding.UTF8, "application/json");
            return POST<Message>(Domain + "api/messages", data, this);
        }

        //TODO TEST
        public Message UpdateMessage(int id, string message)
        {
            return PUT<Message>(Domain + $"api/messages/{id}", this, new KeyValuePair<string, string>("body", message));
        }

        public HttpStatusCode DeleteMessage(int id)
        {
            return DELETE(Domain + $"api/messages/{id}", this);
        }

        //TODO test
        public void GetMessagesAsRead(IdsPicker ids)
        {
            POST<Message>(Domain + "api/messages/mark_read", this,
                new KeyValuePair<string, string>("ids", ids.ToString()),
                new KeyValuePair<string, string>("is_read", "1"));
        }

        public void ReadAllMessages(MessageType type)
        {
            POST<Message>(Domain + "api/messages/read_all", this,
                new KeyValuePair<string, string>("type", Enum<MessageType>.GetName(type)));
        }

        public void DeleteAllMessages(MessageType type)
        {
            POST<Message>(Domain + "api/messages/delete_all", this,
                new KeyValuePair<string, string>("type", Enum<MessageType>.GetName(type)));
        }

        #endregion

        #region People Methods

        public PersonInfo GetPersonInfo(int id)
        {
            return GET<PersonInfo>(Domain + $"api/people/{id}", this);
        }

        public IEnumerable<Character> SearchPerson(SearchRequest request)
        {
            return GET<IEnumerable<Character>>(Domain + "api/people/search", this, request.ToKeyValuePairs());
        }

        #endregion

        #region Publisher Methods

        public IEnumerable<Publisher> GetPublishers()
        {
            return GET<IEnumerable<Publisher>>(Domain + "api/publishers", this);
        }

        #endregion

        #region Ranobe Methods

        public MangaInfo GetRanobeById(int id)
        {
            return GET<MangaInfo>(Domain + $"api/ranobe/{id}", this);
        }

        public IEnumerable<Manga> GetRanobes(MangaListRequest request)
        {
            return GET<IEnumerable<Manga>>(Domain + "api/ranobe", this, request.ToKeyValuePairs());
        }

        public IEnumerable<Role> GetRanobeRoles(int id)
        {
            return GET<IEnumerable<Role>>(Domain + $"api/ranobe/{id}/roles", this);
        }

        public IEnumerable<Manga> GetSimilarRanobes(int id)
        {
            return GET<IEnumerable<Manga>>(Domain + $"api/ranobe/{id}/similar", this);
        }

        public IEnumerable<RelatedTitle> GetRelatedRanobes(int id)
        {
            return GET<IEnumerable<RelatedTitle>>(Domain + $"api/ranobe/{id}/related", this);
        }

        public IEnumerable<ExternalLink> GetRanobeLinks(int id)
        {
            return GET<IEnumerable<ExternalLink>>(Domain + $"api/ranobe/{id}/external_links", this);
        }

        #endregion

        #region Session Methods

        //TODO CREATE

        #endregion

        #region Stats Methods  

        public IEnumerable<int> GetActiveUsers()
        {
            return GET<IEnumerable<int>>(Domain + "api/stats/active_users", this);
        }

        #endregion

        #region Style Methods

        public Style GetStyleById(int id)
        {
            return GET<Style>(Domain + $"api/styles/{id}", this);
        }

        public Style ShowStylePreview(string css)
        {
            return POST<Style>(Domain + "api/styles", this, new KeyValuePair<string, string>("css", css));
        }

        public Style CreateStyle(StyleCreateRequest request)
        {
            return POST<Style>(Domain + "api/styles", this, request.ToKeyValuePairs());
        }

        public Style UpdateStyle(int id, StyleUpdateRequest request)
        {
            return PUT<Style>(Domain + $"api/styles/{id}", this, request.ToKeyValuePairs());
        }

        #endregion

        #region Topic Methods

        //public IEnumerable<Topic> GetTopicList(TopicListRequest request)
        //{
        //    return GET<IEnumerable<Topic>>(Domain + "api/topics", this, request.ToKeyValuePairs());
        //}

        #endregion

        #region User Methods

        public IEnumerable<User> GetUsers(BaseListRequest request)
        {
            return GET<IEnumerable<User>>(Domain + "api/users", this, request.ToKeyValuePairs());
        }

        public UserInfo GetUserInfoById(int id)
        {
            return GET<UserInfo>(Domain + $"api/users/{id}", this);
        }

        public User GetUserById(int id)
        {
            return GET<User>(Domain + $"api/users/{id}/info", this);
        }

        public IEnumerable<User> GetUserFriends(int id)
        {
            return GET<IEnumerable<User>>(Domain + $"api/users/{id}/friends", this);
        }

        public IEnumerable<Club> GetUserClubs(int id)
        {
            return GET<IEnumerable<Club>>(Domain + $"api/users/{id}/clubs", this);
        }

        public IEnumerable<UserListItem> GetUserAnimeRates(int id)
        {
            return GET<IEnumerable<UserListItem>>(Domain + $"api/users/{id}/anime_rates", this);
        }

        public IEnumerable<UserListItem> GetUserMangaRates(int id)
        {
            return GET<IEnumerable<UserListItem>>(Domain + $"api/users/{id}/manga_rates", this);
        }

        //TODO CHECK
        public UserFavorites GetUserFavorites(int id)
        {
            return GET<UserFavorites>(Domain + $"api/users/{id}/favourites", this);
        }

        public IEnumerable<Message> GetMessages(int id)
        {
            return GET<IEnumerable<Message>>(Domain + $"api/users/{id}/messages", this);
        }

        public MessagesCount GetUnreadCountMessages(int id)
        {
            return GET<MessagesCount>(Domain + $"api/users/{id}/unread_messages", this);
        }

        #endregion

        #region Achievements 

        public List<Achievements> GetAchivments(int userId)
        {
            return GET<List<Achievements>>(Domain + "api/achievements", this,
                                           new KeyValuePair<string, string>("user_id", userId.ToString()));
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path without fileName</param>
        public void Save(string path)
        {
            using (var writer = new StreamWriter(Path.Combine(path, "tokens.shiki")))
            {
                writer.WriteLine(timeToExpired);
                writer.WriteLine(refreshToken);
                writer.WriteLine(AccessToken);
                writer.WriteLine(authorizationCode);
                writer.WriteLine(Application.Id);
                writer.WriteLine(Application.Secret);
            }
        }

        /// <param name="path">Path without fileName</param>
        public static Shikimori Load(string path)
        {
            long expiresAt;
            string refreshToken;
            string accessToken;
            string authorizationCode;
            string appId;
            string appSecret;
            using (var reader = new StreamReader(Path.Combine(path, "tokens.shiki"), Encoding.Default))
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

        #endregion

    }
}

