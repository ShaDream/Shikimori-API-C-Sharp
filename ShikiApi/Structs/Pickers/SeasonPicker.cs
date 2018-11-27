using System;
using System.Collections.Generic;
using System.Text;

namespace ShikiApi
{
    public class SeasonPicker
    {
        private readonly HashSet<string> _seasons = new HashSet<string>();

        public void AddSeason(Season season, int year, bool negation = false)
        {
            _seasons.Add(negation ? "!" : "" + Enum<Season>.GetName(season) + $"_{year}");
        }

        public void RemoveSeason(Season season, int year, bool negation = false)
        {
            _seasons.RemoveWhere(x => x == (negation ? "!" : "" + Enum<Season>.GetName(season) + $"_{year}"));
        }

        public void AddYear(int year, bool negation = false)
        {
            _seasons.Add(negation ? "!" : "" + year);
        }

        public void RemoveYear(int year, bool negation = false)
        {
            _seasons.RemoveWhere(x => x == (negation ? "!" : "" + year));
        }

        public void AddGapBetweenYears(int fromYear, int toYear, bool negation = false)
        {
            _seasons.Add(negation ? "!" : "" + $"{fromYear}_{toYear}");
        }

        public void RemoveGapBetweenYears(int fromYear, int toYear, bool negation = false)
        {
            _seasons.RemoveWhere(x => x == (negation ? "!" : "" + $"{fromYear}_{toYear}"));
        }

        /// <summary>
        /// Get decade from year in this decade.
        /// </summary>
        /// <param name="year">year of the decade</param>
        /// <param name="negation"></param>
        /// <returns></returns>
        public void AddDecade(int year, bool negation = false)
        {
            _seasons.Add(negation ? "!" : "" + year.ToString().Remove(year.ToString().Length - 1, 1) + "x");
        }

        public void RemoveDecade(int year, bool negation = false)
        {
            _seasons.RemoveWhere(x =>
                x == (negation ? "!" : "" + year.ToString().Remove(year.ToString().Length - 1, 1) + "x"));
        }

        public override string ToString()
        {
            if (_seasons.Count == 0)
                return string.Empty;

            var result = new StringBuilder();

            foreach (var season in _seasons)
            {
                result.Append(season);
                result.Append(",");
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}