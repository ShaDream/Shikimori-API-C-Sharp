using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShikiApi
{
    public class StudioPicker
    {
        private readonly HashSet<int> Ids = new HashSet<int>();
        public List<Studio> AvaibleStudios { get; private set; }

        public StudioPicker(List<Studio> studios)
        {
            AvaibleStudios = studios;
        }

        #region Methods

        public void AddById(int id)
        {
            var item = AvaibleStudios.SingleOrDefault(x => x.Id == id);
            if (item != null)
                Ids.Add(item.Id);
        }

        public void RemoveById(int id)
        {
            Ids.RemoveWhere(x => x == id);
        }

        public void AddByName(string name)
        {
            var item = AvaibleStudios.SingleOrDefault(x => x.Name == name);
            if (item != null)
                Ids.Add(item.Id);
        }

        public void RemoveByName(string name)
        {
            var item = AvaibleStudios.SingleOrDefault(x => x.Name == name);
            Ids.RemoveWhere(x => x == item?.Id);
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

        #endregion
    }
}