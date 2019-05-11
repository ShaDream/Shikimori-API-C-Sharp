using System.Collections.Generic;
using System.Text;

namespace ShikiApi
{
    public class IdsPicker
    {
        private HashSet<int> Ids { get; set; } = new HashSet<int>();

        public IdsPicker(IEnumerable<int> ids)
        {
            Add(ids);
        }

        public void Add(IEnumerable<int> ids)
        {
            foreach (var t in ids)
                Ids.Add(t);
        }

        public void Add(int id)
        {
            Ids.Add(id);
        }

        public void Remove(int id)
        {
            if (Ids.Contains(id))
                Ids.Remove(id);
        }

        public void Remove(IEnumerable<int> ids)
        {
            foreach (var id in ids)
                if (Ids.Contains(id))
                    Ids.Remove(id);
        }

        public override string ToString()
        {
            if (Ids.Count == 0)
                return string.Empty;

            var result = new StringBuilder();

            foreach (var id in Ids)
            {
                result.Append(id);
                result.Append(",");
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}