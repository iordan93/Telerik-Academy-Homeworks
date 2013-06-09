using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5._7.GenericList;

namespace GenericListTest
{
    [TestClass]
    public class GenericListTest
    {
        [TestMethod]
        public void IndexerTest()
        {
            GenericList<int> list = new GenericList<int>();
            list[0] = 1;
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 0);
            Assert.AreEqual(list[2], 0);
            Assert.AreEqual(list[3], 0);
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
        }

        [TestMethod]
        public void AddTest()
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            Assert.AreEqual(list.Count, 10);
            Assert.AreEqual(list.Capacity, 16);
        }

        [TestMethod]
        public void RemoveTest()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(10);
            list.Add(100);
            list.Add(1000);
            list.Add(10000);
            list.Add(100000);
            list.Remove(3);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Capacity);
            Console.WriteLine(list);
        }

        [TestMethod]
        public void InsertAtTest()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(10);
            list.Add(100);
            list.Add(1000);
            list.Add(10000);
            list.Add(100000);
            list.InsertAt(100000000, 2);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Capacity);
            Console.WriteLine(list);
        }

        [TestMethod]
        public void ClearTest()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(10);
            list.Add(100);
            list.Add(1000);
            list.Add(10000);
            list.Add(100000);
            list.Clear();
            list.Add(1);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list.Capacity, 8);
            Console.WriteLine(list);
        }

        [TestMethod]
        public void FindTest()
        {
            GenericList<string> list = new GenericList<string>();
            list.Add("1");
            list.Add("");
            list.Add("asd");
            list.Add("fgh");
            list.Add("dfsdghgfhgfdgfdgdfgfdgfdgdfgfdgdrg");
            list.Add("s");
            int index = list.Find("asd");
            Assert.AreEqual(index, 2);
            index = list.Find("0");
            Assert.AreEqual(index, -3); // Bitwise complement of the nearest element
        }

        [TestMethod]
        public void MinMaxTest()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(10);
            list.Add(100);
            list.Add(1000);
            list.Add(10000);
            list.Add(100000);

            //Console.WriteLine(list);
            Assert.AreEqual(list.Min<int>(), 1);
            Assert.AreEqual(list.Max<int>(), 100000);

        }
    }
}
