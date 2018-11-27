using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ShikiApi.JSONWriter
{
    public static class AnimeVideoWriterExtension
    {
        public static string ConvertToJsonString(this AnimeSeriesVideo seriesVideo)
        {
            var result = new StringBuilder();
            var sw = new StringWriter(result);

            using (var writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();

                writer.WritePropertyName("anime_video");
                writer.WriteStartObject();

                writer.WriteProperty("anime_id",seriesVideo.AnimeId);
                writer.WriteProperty("author_name", seriesVideo.AuthorName);
                writer.WriteProperty("episode", seriesVideo.Episode);
                writer.WriteProperty("kind", Enum<AnimeSeriesVideoKind>.GetName(seriesVideo.Kind));
                writer.WriteProperty("language", Enum<AnimeSeriesVideoLanguage>.GetName(seriesVideo.Language));
                writer.WriteProperty("quality", Enum<AnimeSeriesVideoQuality>.GetName(seriesVideo.Quality));
                writer.WriteProperty("source", seriesVideo.Source);
                writer.WriteProperty("url", seriesVideo.Url);

                writer.WriteEndObject();
                writer.WriteEndObject();
            }

            return result.ToString();

        }
    }
}