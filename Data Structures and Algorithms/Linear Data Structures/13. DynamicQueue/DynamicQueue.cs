namespace DynamicQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DynamicQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> contents;

        public DynamicQueue()
        {
            this.contents = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.contents.Count;
            }
        }

        public void Enqueue(T value)
        {
            this.contents.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The DynamicQueue is empty.");
            }

            var firstItem = this.contents.First;
            this.contents.RemoveFirst();

            return firstItem.Value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The DynamicQueue is empty.");
            }

            var firstItem = this.contents.First;
            return firstItem.Value;
        }

        public void Clear()
        {
            this.contents.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.contents.GetEnumerator();
        }
    }
}