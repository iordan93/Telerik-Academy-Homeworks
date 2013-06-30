namespace _4.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue>
    {
        private const int DefaultSize = 16;
        private const double OverflowCapacity = 0.75;
        private LinkedList<KeyValuePair<TKey, TValue>>[] data;
        private int count;

        public HashTable()
            : this(DefaultSize)
        {
        }

        public HashTable(int initialCapacity)
        {
            this.data = new LinkedList<KeyValuePair<TKey, TValue>>[initialCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.data.Length;
            }
        }

        public TKey[] Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                for (int list = 0; list < this.data.Length; list++)
                {
                    if (this.data[list] != null)
                    {
                        foreach (KeyValuePair<TKey, TValue> pair in this.data[list])
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys.ToArray();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }

                var index = this.GetArrayIndex(key);

                KeyValuePair<TKey, TValue> result;

                try
                {
                    result = this.GetKeyValuePair(key, index);
                }
                catch (InvalidOperationException)
                {
                    return default(TValue);
                }

                return result.Value;
            }

            set
            {
                this.Add(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (this.Keys.Contains(key))
            {
                throw new InvalidOperationException("The key already exists in the hash table.");
            }

            this.EnsureCapacity();
            int arrayIndex = this.GetArrayIndex(key);

            KeyValuePair<TKey, TValue> newElement = new KeyValuePair<TKey, TValue>(key, value);
            if (this.data[arrayIndex] == null)
            {
                this.data[arrayIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            this.data[arrayIndex].AddLast(newElement);
            this.Count++;
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            int arrayIndex = this.GetArrayIndex(key);

            try
            {
                KeyValuePair<TKey, TValue> result = this.GetKeyValuePair(key, arrayIndex);
                this.data[arrayIndex].Remove(result);
                this.Count--;
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public TValue Find(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            int arrayIndex = this.GetArrayIndex(key);

            try
            {
                return this.GetKeyValuePair(key, arrayIndex).Value;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("The key does not exist in the hash table.");
            }
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultSize];
            this.Count = 0;
        }

        private void EnsureCapacity()
        {
            if (this.Count >= this.Capacity * OverflowCapacity)
            {
                LinkedList<KeyValuePair<TKey, TValue>>[] largerArray = new LinkedList<KeyValuePair<TKey, TValue>>[this.data.Length * 2];
                for (int list = 0; list < this.data.Length; list++)
                {
                    if (this.data[list] != null)
                    {
                        foreach (KeyValuePair<TKey, TValue> pair in this.data[list])
                        {
                            int arrayIndex = this.GetArrayIndex(pair.Key);

                            KeyValuePair<TKey, TValue> newElement = new KeyValuePair<TKey, TValue>(pair.Key, pair.Value);
                            if (largerArray[arrayIndex] == null)
                            {
                                largerArray[arrayIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                            }

                            largerArray[arrayIndex].AddLast(newElement);
                        }
                    }
                }

                this.data = largerArray;
            }
        }

        private int GetArrayIndex(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            int arrayIndex = hash % this.data.Length;

            return arrayIndex;
        }

        private KeyValuePair<TKey, TValue> GetKeyValuePair(TKey key, int index)
        {
            foreach (var pair in this.data[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair;
                }
            }

            throw new InvalidOperationException("The key has not been found in the hash table.");
        }
    }
}