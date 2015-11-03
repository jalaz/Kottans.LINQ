using System.Collections.Generic;

namespace Kottans.LINQ.Tests.Helpers
{
    public static class HashSetProvider
    {
        public static ICollection<T> NewHashSet<T>(IEqualityComparer<T> comparer, params T[] items)
        {
            return new HashSet<T>(items, comparer);
        }
    }
}
