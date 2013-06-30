namespace SortindAndSearchingAlgorithmsTests
{
    using System;
    using System.Collections.Generic;    
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingAndSearchingAlgorithms;

    [TestClass]
    public class MergeSorterTests
    {
        private static readonly MergeSorter<int> sorter = new MergeSorter<int>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSortNullCollection()
        {
            int[] collection = null;
            sorter.Sort(collection);
        }

        [TestMethod]
        public void TestSortSingleElement()
        {
            List<int> item = new List<int>() { 1 };
            sorter.Sort(item);

            Assert.IsTrue(IsSorted(item));
        }

        [TestMethod]
        public void TestSortRandomCollection()
        {
            IList<int> collection = Utilities.GetRandomCollection(1000);
            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        [TestMethod]
        public void TestSortAlreadySortedCollection()
        {
            IList<int> collection = Utilities.GetSortedCollection(1000);
            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        [TestMethod]
        public void TestSortReversedCollection()
        {
            IList<int> collection = Utilities.GetReversedCollection(1000);
            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        [TestMethod]
        public void TestSortCollectionWithFewUniqueItems()
        {
            IList<int> collection = Utilities.GetFewUniqueItemsCollection(1000, 5);
            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        private static bool IsSorted(IList<int> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i] > collection[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
