using System;
using System.Collections;
using System.Collections.Generic;

namespace Kottans.LINQ.Tests.Helpers
{
    /// <summary>
    /// Implementation of ICollection[T] (but not IList[T]) which can't be iterated over.
    /// </summary>
    public class NonEnumerableCollection<T> : ICollection<T>
    {
        private readonly List<T> backingList = new List<T>();

        public void Add(T item)
        {
            backingList.Add(item);
        }

        public void Clear()
        {
            backingList.Clear();
        }

        public bool Contains(T item)
        {
            return backingList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            backingList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return backingList.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<T>)backingList).IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return backingList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
