namespace _5.HashedSetTests
{
    using System;
    using System.Linq;
    using _5.HashedSet;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashedSetTests
    {
        [TestMethod]
        public void TestHashedSetConstructor()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            Assert.IsNotNull(hashedSet);
            Assert.IsInstanceOfType(hashedSet, typeof(HashedSet<int>));
        }

        [TestMethod]
        public void TestAddSingleItem()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);

            Assert.AreEqual(hashedSet.Count, 1);
            Assert.IsTrue(hashedSet.Contains(3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicate()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNull()
        {
            HashedSet<object> hashTable = new HashedSet<object>();

            hashTable.Add(null);
        }

        [TestMethod]
        public void TestAddManyItems()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);

            Assert.AreEqual(5, hashedSet.Count);
            Assert.IsTrue(hashedSet.Contains(3));
            Assert.IsTrue(hashedSet.Contains(5));
            Assert.IsTrue(hashedSet.Contains(45213214));
            Assert.IsTrue(hashedSet.Contains(4561));
            Assert.IsTrue(hashedSet.Contains(15));
        }

        [TestMethod]
        public void TestResizeTable()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            Random generator = new Random();
            for (int i = 0; i < 20; i++)
            {
                hashedSet.Add(generator.Next());
            }

            Assert.AreEqual(20, hashedSet.Count);
            Assert.AreEqual(32, hashedSet.Capacity);
        }

        [TestMethod]
        public void TestRemoveSingleItem()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);
            hashedSet.Remove(15);

            Assert.AreEqual(4, hashedSet.Count);
            Assert.IsFalse(hashedSet.Contains(15));
        }

        [TestMethod]
        public void TestRemoveManyItems()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();
            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);
            hashedSet.Remove(15);
            hashedSet.Remove(4561);
            hashedSet.Remove(5);

            Assert.AreEqual(2, hashedSet.Count);
            Assert.IsFalse(hashedSet.Contains(15));
            Assert.IsFalse(hashedSet.Contains(4561));
            Assert.IsFalse(hashedSet.Contains(5));
        }

        [TestMethod]
        public void TestRemoveNonexistingItem()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);
            hashedSet.Remove(4561);

            bool removed = hashedSet.Remove(55555);
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void TestRemoveTwice()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);

            bool firstRemoved = hashedSet.Remove(45213214);
            bool secondRemoved = hashedSet.Remove(45213214);

            Assert.IsTrue(firstRemoved);
            Assert.IsFalse(secondRemoved);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNull()
        {
            HashedSet<object> hashedSet = new HashedSet<object>();

            hashedSet.Add(3);
            hashedSet.Remove(null);
        }

        [TestMethod]
        public void TestFindSingleItem()
        {
            HashedSet<int> hashTable = new HashedSet<int>();

            hashTable.Add(3);
            hashTable.Add(5);
            hashTable.Add(45213214);
            hashTable.Add(4561);
            hashTable.Add(15);

            Assert.IsTrue(hashTable.Find(15));
        }

        [TestMethod]
        public void TestFindManyItems()
        {
            HashedSet<int> hashTable = new HashedSet<int>();

            hashTable.Add(3);
            hashTable.Add(5);
            hashTable.Add(45213214);
            hashTable.Add(4561);
            hashTable.Add(15);

            Assert.IsTrue(hashTable.Find(15));
            Assert.IsTrue(hashTable.Find(3));
            Assert.IsTrue(hashTable.Find(5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindNonexistingItem()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);

            Assert.IsTrue(hashedSet.Find(15));

            hashedSet.Find(188);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindNull()
        {
            HashedSet<object> hashTable = new HashedSet<object>();

            hashTable.Add(3);
            hashTable.Add("some text");
            hashTable.Find(null);
        }

        [TestMethod]
        public void TestClear()
        {
            HashedSet<int> hashedSet = new HashedSet<int>();

            hashedSet.Add(3);
            hashedSet.Add(5);
            hashedSet.Add(45213214);
            hashedSet.Add(4561);
            hashedSet.Add(15);

            hashedSet.Clear();

            Assert.AreEqual(0, hashedSet.Count);
        }

        [TestMethod]
        public void TestUnionWithDifferentItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(48);
            second.Add(598);
            second.Add(154);
            second.Add(1564523);
            second.Add(5461);

            first.UnionWith(second);

            Assert.AreEqual(10, first.Count);
            Assert.IsTrue(first.Contains(48));
            Assert.IsTrue(first.Contains(598));
            Assert.IsTrue(first.Contains(154));
            Assert.IsTrue(first.Contains(1564523));
            Assert.IsTrue(first.Contains(5461));
        }

        [TestMethod]
        public void TestUnionWithSameItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(3);
            second.Add(5);
            second.Add(45213214);
            second.Add(4561);
            second.Add(15);

            first.UnionWith(second);

            Assert.AreEqual(5, first.Count);
            Assert.IsTrue(first.Contains(3));
            Assert.IsTrue(first.Contains(5));
            Assert.IsTrue(first.Contains(45213214));
            Assert.IsTrue(first.Contains(4561));
            Assert.IsTrue(first.Contains(15));
        }

        [TestMethod]
        public void TestUnionWithSomeDifferentItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(3);
            second.Add(5);
            second.Add(165);
            second.Add(222);
            second.Add(89988);

            first.UnionWith(second);

            Assert.AreEqual(8, first.Count);
            Assert.IsTrue(first.Contains(3));
            Assert.IsTrue(first.Contains(5));
            Assert.IsTrue(first.Contains(45213214));
            Assert.IsTrue(first.Contains(4561));
            Assert.IsTrue(first.Contains(15));
            Assert.IsTrue(first.Contains(165));
            Assert.IsTrue(first.Contains(222));
            Assert.IsTrue(first.Contains(89988));
        }

        [TestMethod]
        public void TestIntersectWithDifferentItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(48);
            second.Add(598);
            second.Add(154);
            second.Add(1564523);
            second.Add(5461);

            HashedSet<int> result = first.IntersectWith(second);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestIntersectWithSameItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(3);
            second.Add(5);
            second.Add(45213214);
            second.Add(4561);
            second.Add(15);

            HashedSet<int> result = first.IntersectWith(second);

            Assert.AreEqual(5, result.Count);
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(result.Contains(5));
            Assert.IsTrue(result.Contains(45213214));
            Assert.IsTrue(result.Contains(4561));
            Assert.IsTrue(result.Contains(15));
        }

        [TestMethod]
        public void TestIntersectWithSomeDifferentItems()
        {
            HashedSet<int> first = new HashedSet<int>();
            first.Add(3);
            first.Add(5);
            first.Add(45213214);
            first.Add(4561);
            first.Add(15);

            HashedSet<int> second = new HashedSet<int>();
            second.Add(3);
            second.Add(5);
            second.Add(165);
            second.Add(222);
            second.Add(89988);

            HashedSet<int> result = first.IntersectWith(second);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(result.Contains(5));
        }
    }
}
