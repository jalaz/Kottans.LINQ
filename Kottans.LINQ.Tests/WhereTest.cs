using System;
using System.Collections.Generic;
using System.Linq;
using Kottans.LINQ.Tests.Helpers;
using NUnit.Framework;

namespace Kottans.LINQ.Tests
{
    public class WhereTest
    {
        [Test]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [Test]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void WithIndexNullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x > 5));
        }

        [Test]
        public void WithIndexNullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void SimpleFiltering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            result.AssertSequenceEqual(1, 3, 2, 1);
        }

        [Test]
        public void SimpleFilteringWithQueryExpression()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x;
            result.AssertSequenceEqual(1, 3, 2, 1);
        }

        [Test]
        public void EmptySource()
        {
            int[] source = new int[0];
            var result = source.Where(x => x < 4);
            result.AssertSequenceEqual();
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where(x => x > 0));
        }

        [Test]
        public void WithIndexSimpleFiltering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where((x, index) => x < index);
            result.AssertSequenceEqual(2, 1);
        }

        [Test]
        public void WithIndexEmptySource()
        {
            int[] source = new int[0];
            var result = source.Where((x, index) => x < 4);
            result.AssertSequenceEqual();
        }

        [Test]
        public void WithIndexExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where((x, index) => x > 0));
        }
    }
}
