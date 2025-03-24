using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SeleniumTests.Utilities
{
    public static class SortingHelper
    {
        public static bool IsSorted<T>(List<T> list, bool ascending = true) where T : IComparable<T>
        {
            var sortedList = ascending ? list.OrderBy(x => x).ToList() : list.OrderByDescending(x => x).ToList();
            return list.SequenceEqual(sortedList);
        }

        public static List<string> ExtractTextFromCells(List<string> cellValues)
        {
            return cellValues.Select(value => value.Trim()).ToList();
        }
    }
}
