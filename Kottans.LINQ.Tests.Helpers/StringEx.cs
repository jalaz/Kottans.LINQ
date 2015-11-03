using System.Collections.Generic;
using System.Linq;

namespace Kottans.LINQ.Tests.Helpers
{
    public static class StringEx
    {
        public static string Join<T>(string delimiter, IEnumerable<T> source)
        {
            return string.Join(delimiter, source.Select(x => x.ToString()).ToArray());
        }
    }
}
