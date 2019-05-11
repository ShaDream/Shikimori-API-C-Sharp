using System;
using System.Collections.Generic;

namespace ShikiApi
{
    public class User
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public AvatarImages Image { get; set; }
        public DateTime LastOnline { get; set; }
    }
}