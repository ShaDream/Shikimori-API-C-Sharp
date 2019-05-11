using System.Collections.Generic;

namespace ShikiApi
{
    public abstract class Request
    {
        public KeyValuePair<string, string>[] ToKeyValuePairs()
        {
            var parametrs = new List<KeyValuePair<string, string>>();

            foreach (var publicProperty in GetType().GetPublicProperties())
            {
                if (publicProperty.TryGetKeyValuePair(this, out var pair))
                    parametrs.Add(pair.Value);
            }

            return parametrs.ToArray();
        }
    }
}