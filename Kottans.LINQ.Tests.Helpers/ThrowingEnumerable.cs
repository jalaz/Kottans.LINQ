using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Kottans.LINQ.Tests.Helpers
{
    public sealed class ThrowingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static void AssertDeferred<T>(
            Func<IEnumerable<int>, IEnumerable<T>> deferredFunction)
        {
            ThrowingEnumerable source = new ThrowingEnumerable();
            var result = deferredFunction(source);
            using (var iterator = result.GetEnumerator())
            {
                Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
            }
        }
    }
}
