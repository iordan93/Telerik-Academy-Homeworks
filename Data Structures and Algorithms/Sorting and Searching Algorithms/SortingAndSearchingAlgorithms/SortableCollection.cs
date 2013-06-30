namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new QuickSorter<T>());

            int startIndex = 0;
            int endIndex = this.items.Count - 1;
            int resultIndex = -1;
            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                if (item.CompareTo(this.Items[middleIndex]) < 0)
                {
                    endIndex = middleIndex - 1;
                }
                else if (item.CompareTo(this.Items[middleIndex]) > 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    resultIndex = middleIndex;
                    break;
                }
            }

            if (resultIndex != -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Shuffling using Fisher-Yates algorithm.
        /// Complexity: O(n)
        /// </summary>
        public void Shuffle()
        {
            Random generator = new Random();

            for (int i = this.Items.Count - 1; i > 0; i--)
            {
                int randomIndex = generator.Next(0, i);

                Swap(this.Items, i, randomIndex);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private static void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T temporaryStorage = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temporaryStorage;
        }
    }
}
