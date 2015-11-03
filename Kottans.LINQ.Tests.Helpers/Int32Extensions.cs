using System.Globalization;

namespace Kottans.LINQ.Tests.Helpers
{
    public static class Int32Extensions
    {
        public static string ToInvariantString(this int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
