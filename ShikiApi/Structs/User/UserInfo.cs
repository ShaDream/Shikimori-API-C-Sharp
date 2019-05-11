namespace ShikiApi
{
    public class UserInfo : User
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int FullYears { get; set; }
        public string LastOnline { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public bool IsBanned { get; set; }
        public string About { get; set; }
        public string AboutHtml { get; set; }
        public string[] CommonInfo { get; set; }
        public bool ShowComments { get; set; }
        public User[] InFriends { get; set; }
        public bool IsIgnored { get; set; }

    }
}