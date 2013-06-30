using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAndSearchingAlgorithms;

namespace SortindAndSearchingAlgorithmsTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void TestSearchNonExistingItem()
        {
            List<int> items = new List<int>() { 5, -50, 30, 5462, 564531234, -1453122, 0, 546545, 1897, 6, 12, 36, 487, 649, -4655 };

            SortableCollection<int> collection = new SortableCollection<int>(items);
            bool found = collection.BinarySearch(-2556);

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void TestSearchExistingItem()
        {
            List<int> items = new List<int>() { 5, -50, 30, 5462, 564531234, -1453122, 0, 546545, 1897, 6, 12, 36, 487, 649, -4655 };

            SortableCollection<int> collection = new SortableCollection<int>(items);
            bool found = collection.BinarySearch(564531234);

            Assert.IsTrue(found);
        }
    }
}
