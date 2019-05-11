using System.Linq;
using System.Net.Http;
using System.Text;

namespace ShikiApi
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullOrWhiteSpace(this string str, params string[] other)
        {
            return str.IsNullOrWhiteSpace() && other.All(x => x.IsNullOrWhiteSpace());
        }
    }
}