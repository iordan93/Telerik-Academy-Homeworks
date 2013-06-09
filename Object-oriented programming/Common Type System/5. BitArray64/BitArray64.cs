using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        // Private fields
        private ulong number = 0;
        private byte bitCapacity = 64;
        private int count;
        private int capacity;

        // Public properties to encapsulate the fields
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
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        // Constructors
        public BitArray64()
            : this(0)
        {
        }

        public BitArray64(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "The length must be nonnegative.");
            }
            this.number = 0;
            this.Count = length;
            this.Capacity = bitCapacity;
        }

        // Indexer
        public int this[int index]
        {
            // Get the value at the given index
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return (int)(this.number >> index) & 1;
            }

            // Set the value at a given index
            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("bit", "The value of a bit can only be 0 or 1.");
                }

                // If the value is one, set the bit at the given position at 1
                if (value == 1)
                {
                    this.number = this.number | (1UL << index);
                }

                // If the value is 0, set the bit at the given position at 0
                else
                {
                    this.number = this.number & ~(1UL << index);
                }
            }
        }

        // Methods
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        // Get each element in a sequential order
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        // Check for equality of the numbers
        public override bool Equals(object obj)
        {
            return this.number.Equals((obj as BitArray64).number);
        }

        // Get the hash code of the number
        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        // Write the bit array as string - get the bit at each position
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                output.Append((number >> i) & 1);
            }
            return output.ToString();
        }

        // The equality and inequality checks call the Equals method
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}
