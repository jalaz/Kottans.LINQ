﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Kottans.LINQ.Tests.Helpers
{
    public class SemiGenericCollection : ICollection, IEnumerable<int>
    {
        private readonly List<int> list;

        public SemiGenericCollection()
        {
            list = new List<int>();
        }

        public SemiGenericCollection(IEnumerable<int> items)
        {
            list = new List<int>(items);
        }

        public void Add(int item)
        {
            list.Add(item);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)list).CopyTo(array, index);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }
    }
}
