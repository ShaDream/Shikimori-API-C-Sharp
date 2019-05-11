using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShikiApi
{
    public class PersonGrouppedRoleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PersonGrouppedRole);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var array = JArray.Load(reader);
            var grouppedRole = (existingValue as PersonGrouppedRole ?? new PersonGrouppedRole());
            grouppedRole.Name = (string)array.ElementAtOrDefault(0);
            grouppedRole.Id = (int)array.ElementAtOrDefault(1);
            return grouppedRole;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var grouppedRole = (PersonGrouppedRole)value;
            serializer.Serialize(writer, new[] { grouppedRole.Name, grouppedRole.Id.ToString() });
        }
    }
}