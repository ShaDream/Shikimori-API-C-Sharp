using System;
using System.Collections.Generic;
using System.Text;

namespace ShikiApi
{
    public class AnimeKindPicker
    {
        private readonly HashSet<string> _kinds = new HashSet<string>();

        public void AddKind(AnimeKindRequest kind, bool negation = false)
        {
            _kinds.Add(negation ? "!" : "" + Enum.GetName(typeof(AnimeKindRequest), kind));
        }

        public void RemoveKind(AnimeKindRequest kind, bool negation = false)
        {
            _kinds.RemoveWhere(x => x == (negation ? "!" : "" + Enum.GetName(typeof(AnimeKindRequest), kind)));
        }

        public override string ToString()
        {
            if (_kinds.Count == 0)
                return string.Empty;

            var result = new StringBuilder();

            foreach (var season in _kinds)
            {
                result.Append(season);
                result.Append(",");
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}