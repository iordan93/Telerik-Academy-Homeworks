using System;
using System.Linq;
using System.Text;

namespace _5._7.GenericList
{
    public class GenericList<T>
    {
        // Private fields - internal array, capacity, and count 
        private T[] array;
        private int capacity;
        private int count;

        // Public properties - capacity and count (public reading, private writing)
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
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

        // Constructors
        // Empty constructor - create an array with 4 elements by default
        public GenericList()
        {
            this.array = new T[4];
            this.Count = 0;
            this.Capacity = 4;
        }

        // Constructor with specified length
        public GenericList(int length)
        {
            this.array = new T[length];
            this.Count = 0;
            this.Capacity = length;
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if ((index >= 0) && (index < array.Length))
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("The index of the element in GenericList must be nonnegative.");
                }

            }
            set
            {
                if ((index >= 0) && (index < array.Length))
                {
                    array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The index of the element in GenericList must be nonnegative.");
                }
            }
        }

        // Instance methods
        // Add an element to the GenericList
        public void Add(T value)
        {
            EnsureCapacity();
            array[count] = value;
            this.Count++;
        }

        // Remove an element from the GenericList by index
        public void Remove(int index)
        {
            if ((index >= 0) && (index < this.Count))
            {
                T[] buffer = new T[this.Capacity];
                for (int i = 0, position = 0; i < array.Length; i++, position++)
                {
                    // If the index to remove is reached, the next, decrease the position in the buffer
                    // to avoid adding zeroes instead of removing an element
                    if (i == index)
                    {
                        position--;
                        continue;
                    }

                    else
                    {
                        buffer[position] = this.array[i];
                    }
                }
                this.array = buffer;
                this.Count--;
            }
            else
            {
                throw new IndexOutOfRangeException("The index must be nonnegative and less than the size of the GenericList");
            }
        }

        // Insert element at a given index
        public void InsertAt(T value, int index)
        {
            if ((index >= 0) && (index < this.Count))
            {
                T[] buffer = new T[this.Capacity + 1];
                for (int i = 0, position = 0; i < array.Length - 1; position++)
                {
                    // If the position in the buffer has reached the one we are looking for, write the value.
                    // Else, copy the array element by element
                    if (position == index)
                    {
                        buffer[position] = value;
                        continue;
                    }
                    else
                    {
                        buffer[position] = this.array[i];
                        i++;
                    }
                }
                this.array = buffer;
                this.Count++;
            }
            else
            {
                throw new IndexOutOfRangeException("The index must be nonnegative and less than the size of the GenericList");
            }
        }

        // Clear the GenericList
        public void Clear()
        {
            T[] buffer = new T[this.Capacity];
            array = buffer;
            this.Count = 0;
            this.Capacity = buffer.Length;
        }

        // Find element by value
        public int Find(T element)
        {
            return Array.BinarySearch<T>(array, element);
        }

        // Write the GenericList as string
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                builder.AppendFormat("{0} -> {1}\n", index, array[index]);
            }
            return builder.ToString();
        }

        // Minimum element (restricted only to elements that can be compared)
        public T Min<T>() where T : IComparable<T>
        {
            // Suppose the minimum element is the first one and try to find a smaller element
            dynamic min = this.array[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = (dynamic)this.array[i];
                if (listItem.CompareTo(min) < 0)
                {
                    min = this.array[i];
                }
            }
            return min;
        }

        // Maximum element
        public T Max<T>() where T : IComparable<T>
        {
            // Suppose the maximum element is the first one and try to find a larger element
            dynamic max = this.array[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = (dynamic)this.array[i];
                if (listItem.CompareTo(max) > 0)
                {
                    max = this.array[i];
                }
            }
            return max;
        }

        // Ensure capacity
        private void EnsureCapacity()
        {
            if (this.Count == this.Capacity)
            {
                T[] buffer = new T[this.Capacity * 2];
                for (int index = 0; index < array.Length; index++)
                {
                    buffer[index] = array[index];
                }
                this.array = buffer;
                this.Capacity = buffer.Length;
            }
            else return;
        }
    }
}
