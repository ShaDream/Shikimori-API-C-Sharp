using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserListItemRequest : Request
    {
        [String("user_id")]
        [DefaultValue(0)]
        public int UserID { get; set; } = 0;

        [String("target_id")]
        [DefaultValue(0)]
        public int TargetID { get; set; } = 0;

        [String("target_type")]
        public TypeOfTitle? TargetType { get; set; } = null;

        [String("status")]
        public UserItemStatus? Status { get; set; } = null;

        [String("page")]
        [DefaultValue(0)]
        public int Page { get; set; } = 0;

        [String("limit")]
        [DefaultValue(0)]
        public int Limit { get; set; } = 0;
    }
}