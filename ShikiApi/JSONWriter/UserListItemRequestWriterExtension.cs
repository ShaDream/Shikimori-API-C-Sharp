using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace ShikiApi.JSONWriter
{
    public static class UserListItemRequestWriterExtension
    {
        public static string ConvertToJsonString(this UserListItem itemRequest)
        {
            var result = new StringBuilder();
            var sw = new StringWriter(result);

            using (var writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();

                writer.WritePropertyName("user_rate");

                writer.WriteStartObject();

                writer.WriteProperty("chapters", itemRequest.Chapters);
                writer.WriteProperty("episodes", itemRequest.Episodes);
                writer.WriteProperty("rewatches", itemRequest.Rewatches);
                writer.WriteProperty("score", itemRequest.Score);
                writer.WriteProperty("status", Enum<UserItemStatus>.GetName(itemRequest.Status));
                writer.WriteProperty("target_id", itemRequest.TargetID);
                writer.WriteProperty("target_type", itemRequest.TargetType);
                writer.WriteProperty("text", itemRequest.Text);
                writer.WriteProperty("user_id", itemRequest.UserID);
                writer.WriteProperty("volumes", itemRequest.Volumes);

                writer.WriteEndObject();

                writer.WriteEndObject();
            }

            return result.ToString();
        }

        public static void WriteProperty(this JsonTextWriter w, string property, object value)
        {
            w.WritePropertyName(property);
            w.WriteValue(value);
        }
    }
}