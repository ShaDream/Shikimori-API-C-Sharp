using System;

namespace ShikiApi
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTime(this DateTime time)
        {
            return ((DateTimeOffset)time).ToUnixTimeSeconds();
        }

        public static DateTime UnixTimeStampToDateTime(this long unixTimeSeconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).DateTime;
        }
    }
}