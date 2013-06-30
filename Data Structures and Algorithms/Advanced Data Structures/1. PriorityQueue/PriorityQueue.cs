namespace _1.PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
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

        public void Enqueue(T item)
        {
            // Add the item to the end of the heap and rebalance as the abstract data type requires
            this.data.Add(item);

            for (int i = this.data.Count - 1; i > 0; i = (i - 1) / 2)
            {
                if (this.data[(i - 1) / 2].CompareTo(this.data[i]) < 0)
                {
                    this.Swap(i, (i - 1) / 2);
                }
            }
        }

        public T Dequeue()
        {
            // Save the result and rebalance the heap as the abstract data type requires
            T removedItem = this.data[0];

            this.Swap(0, this.Count - 1);
            this.data.RemoveAt(this.data.Count - 1);

            for (int i = 0, biggerChildIndex; (2 * i) + 1 < this.Count; i = biggerChildIndex)
            {
                biggerChildIndex = (2 * i) + 1;
                if ((2 * i) + 2 < this.Count && this.data[(2 * i) + 2].CompareTo(this.data[(2 * i) + 1]) > 0)
                {
                    biggerChildIndex = (2 * i) + 2;
                }

                if (this.data[i].CompareTo(this.data[biggerChildIndex]) < 0)
                {
                    this.Swap(i, biggerChildIndex);
                }
                else
                {
                    break;
                }
            }

            return removedItem;
        }

        public T Peek()
        {
            // Return the highest priority item, i. e. the current root
            return this.data[0];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T oldFirst = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = oldFirst;
        }
    }
}
