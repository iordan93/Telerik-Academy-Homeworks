namespace _5.HashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using _4.HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private readonly HashTable<T, bool> data;

        public HashedSet()
        {
            this.data = new HashTable<T, bool>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.data.Capacity;
            }
        }

        public void Add(T item)
        {
            if (!this.data.Keys.Contains(item))
            {
                this.data.Add(item, true);
            }
            else
            {
                throw new InvalidOperationException("The item already exists in the HashedSet.");
            }
        }

        public bool Find(T item)
        {
            try
            {
                return this.data[item] == true;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("The item does not exist in the HashedSet.");
            }
        }

        public bool Remove(T item)
        {
            return this.data.Remove(item);
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public HashedSet<T> UnionWith(HashedSet<T> otherHashedSet)
        {
            if (otherHashedSet == null)
            {
                throw new ArgumentNullException("otherHashedSet");
            }

            foreach (T item in otherHashedSet)
            {
                if (!this.data.Keys.Contains(item))
                {
                    this.data.Add(item, true);
                }
            }

            return this;
        }

        public HashedSet<T> IntersectWith(HashedSet<T> otherHashedSet)
        {
            if (otherHashedSet == null)
            {
                throw new ArgumentNullException("otherHashedSet");
            }

            var combinedHashedSet = new HashedSet<T>();

            foreach (T item in this)
            {
                if (otherHashedSet.Contains(item))
                {
                    combinedHashedSet.Add(item);
                }
            }

            return combinedHashedSet;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.data.Keys)
            {
                yield return item;
            }
        }
    }
}
