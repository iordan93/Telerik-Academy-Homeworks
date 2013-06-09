namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private T[] contents;
        private int count;
        private int headPointer = -1;

        public Stack(int capacity)
        {
            this.contents = new T[capacity];
            this.count = 0;
            this.headPointer = -1;
        }

        public Stack()
            : this(0)
        {
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

        public void Push(T value)
        {
            this.headPointer++;

            if (this.contents.Length <= this.headPointer)
            {
                this.EnsureCapacity();
            }

            this.contents[this.headPointer] = value;
            this.Count++;
        }

        public T Pop()
        {
            if (this.headPointer == -1)
            {
                throw new InvalidOperationException("The Stack is empty.");
            }

            T poppedElement = this.contents[this.headPointer];
            this.contents[this.headPointer] = default(T);
            this.headPointer--;
            this.Count--;
            return poppedElement;
        }

        public T Peek()
        {
            if (this.headPointer == -1)
            {
                throw new InvalidOperationException("The Stack is empty.");
            }
            else
            {
                return this.contents[this.headPointer];
            }
        }

        public void Clear()
        {
            this.contents = new T[0];
            this.headPointer = -1;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Return the elements in reverse order, the way they will be popped out
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.contents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureCapacity()
        {
            int newLength = 0;
            if (this.contents.Length == 0)
            {
                newLength = 4;
            }
            else
            {
                newLength = 2 * this.contents.Length;
            }

            this.CreateLargerArray(newLength);
        }
  
        private void CreateLargerArray(int newLength)
        {
            T[] newArray = new T[newLength];
            for (int i = 0; i < this.contents.Length; i++)
            {
                newArray[i] = this.contents[i];
            }

            this.contents = newArray;
        }
    }
}