﻿using System;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserListItem : UserListItemRequest
    {

        [JsonProperty(PropertyName = "Created_At")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "Updated_At")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserID { get; set; }

        [JsonProperty(PropertyName = "target_id")]
        public int TargetID { get; set; }

        [JsonProperty(PropertyName = "target_type")]
        public TypeOfTitle? TargetType { get; set; }

        public int ID { get; set; }
        public int Score { get; set; }
        public int Rewatches { get; set; }
        public int? Episodes { get; set; }
        public int? Volumes { get; set; }
        public int? Chapters { get; set; }
        public string Text { get; set; }
        public UserItemStatus? Status { get; set; } = null;
    }
}