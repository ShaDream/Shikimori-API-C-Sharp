using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace ShikiApi
{
    public class UserListItemRequest : BaseListRequest
    {
        [Request(Name = "user_id", DefaultValue = 0)]
        public int UserId { get; set; } = 0;

        [Request(Name = "target_id", DefaultValue = 0)]
        public int TargetId { get; set; } = 0;

        [Request(Name = "target_type")]
        public TypeOfTitle? TargetType { get; set; } = null;

        [Request(Name = "status")]
        public UserItemStatus? Status { get; set; } = null;
    }
}