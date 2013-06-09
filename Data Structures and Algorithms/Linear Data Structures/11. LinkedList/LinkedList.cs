namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> first;
        private ListItem<T> last;
        private int count = 0;

        public ListItem<T> First
        {
            get
            {
                return this.first;
            }

            private set
            {
                this.first = value;
            }
        }

        public ListItem<T> Last
        {
            get
            {
                return this.last;
            }

            private set
            {
                this.last = value;
            }
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

        public void AddFirst(T value)
        {
            ListItem<T> currentItem = new ListItem<T>(value);

            if (this.First == null)
            {
                this.First = this.Last = currentItem;
            }
            else
            {
                this.First.PreviousItem = currentItem;
                currentItem.NextItem = this.First;
                this.First = currentItem;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            ListItem<T> currentItem = new ListItem<T>(value);

            if (this.Last == null)
            {
                this.First = this.Last = currentItem;
            }
            else
            {
                this.Last.NextItem = currentItem;
                currentItem.PreviousItem = this.Last;
                this.Last = currentItem;
            }

            this.Count++;
        }

        public ListItem<T> RemoveFirst()
        {
            if (this.First == null)
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            ListItem<T> firstItem = this.First;

            if (this.First.NextItem == null)
            {
                this.First = this.Last = null;
            }
            else
            {
                this.First = this.First.NextItem;
                this.First.PreviousItem = null;
            }

            this.Count--;
            firstItem = UnlinkItem(firstItem);
            return firstItem;
        }

        public ListItem<T> RemoveLast()
        {
            if (this.Last == null)
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            ListItem<T> lastItem = this.Last;

            if (this.Last.PreviousItem == null)
            {
                this.First = this.Last = null;
            }
            else
            {
                this.Last = this.Last.PreviousItem;
                this.Last.NextItem = null;
            }

            this.Count--;
            lastItem = UnlinkItem(lastItem);
            return lastItem;
        }

        public ListItem<T> Find(T value)
        {
            ListItem<T> currentItem = this.First;
            while (currentItem != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    return currentItem;
                }

                currentItem = currentItem.NextItem;
            }

            return null;
        }

        public ListItem<T> FindLast(T value)
        {
            ListItem<T> currentItem = this.Last;
            while (currentItem != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    return currentItem;
                }

                currentItem = currentItem.PreviousItem;
            }

            return null;
        }

        public void Clear()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> currentItem = this.First;
            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.NextItem;
            }
        }

        private static ListItem<T> UnlinkItem(ListItem<T> item)
        {
            item.PreviousItem = null;
            item.NextItem = null;
            return item;
        }
    }
}