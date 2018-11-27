using System.Collections.Generic;

namespace ShikiApi
{
    public static class ListKeyValuePairExtension
    {
        public static void AddIf(this List<KeyValuePair<string, string>> list, KeyValuePair<string, string> value, bool check)
        {
            if(check)
                list.Add(value);
        }
    }
}