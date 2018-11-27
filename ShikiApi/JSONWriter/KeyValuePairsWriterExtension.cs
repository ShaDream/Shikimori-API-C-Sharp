using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ShikiApi.JSONWriter
{
    public static class KeyValuePairsWriterExtension
    {
        public static string ConvertToJsonString(this KeyValuePair<string, string>[] array)
        {
            var result = new StringBuilder();
            var sw = new StringWriter(result);

            using (var writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();

                foreach (var pair in array)
                {
                    writer.WritePropertyName(pair.Key);
                    writer.WriteValue(pair.Value);
                }

                writer.WriteEndObject();
            }

            return result.ToString();
        }
    }
}