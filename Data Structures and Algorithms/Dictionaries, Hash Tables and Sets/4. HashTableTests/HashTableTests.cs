namespace _4.HashTableTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _4.HashTable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void TestHashTableConstructor()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            Assert.IsNotNull(hashTable);
            Assert.IsInstanceOfType(hashTable, typeof(HashTable<string, int>));
        }

        [TestMethod]
        public void TestAddSingleItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            hashTable.Add("abc", 3);
            
            Assert.AreEqual(hashTable.Count, 1);
            Assert.IsTrue(hashTable.Keys.Contains("abc"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            hashTable.Add("abc", 3);
            hashTable.Add("abc", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add(null, 5);
        }

        [TestMethod]
        public void TestAddManyItems()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            Assert.AreEqual(5, hashTable.Count);
            Assert.IsTrue(hashTable.Keys.Contains("abc"));
            Assert.IsTrue(hashTable.Keys.Contains("def"));
            Assert.IsTrue(hashTable.Keys.Contains("ghi"));
            Assert.IsTrue(hashTable.Keys.Contains("jkl"));
            Assert.IsTrue(hashTable.Keys.Contains("mnop"));
        }

        [TestMethod]
        public void TestResizeTable()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            Random generator = new Random();
            for (int i = 0; i < 20; i++)
            {
                hashTable.Add(generator.Next().ToString(), generator.Next());
            }

            Assert.AreEqual(20, hashTable.Count);
            Assert.AreEqual(32, hashTable.Capacity);
        }

        [TestMethod]
        public void TestRemoveSingleKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);
            hashTable.Remove("jkl");

            Assert.AreEqual(4, hashTable.Count);
            Assert.IsFalse(hashTable.Keys.Contains("jkl"));
        }

        [TestMethod]
        public void TestRemoveManyKeys()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);
            hashTable.Remove("jkl");
            hashTable.Remove("abc");
            hashTable.Remove("mnop");

            Assert.AreEqual(2, hashTable.Count);
            Assert.IsFalse(hashTable.Keys.Contains("jkl"));
            Assert.IsFalse(hashTable.Keys.Contains("abc"));
            Assert.IsFalse(hashTable.Keys.Contains("mnop"));
        }

        [TestMethod]
        public void TestRemoveNonexistingKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            
            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);
            hashTable.Remove("jkl");
            
            bool removed = hashTable.Remove("zzz");
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void TestRemoveTwice()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);
            
            bool firstRemoved = hashTable.Remove("jkl");
            bool secondRemoved = hashTable.Remove("jkl");
            
            Assert.IsTrue(firstRemoved);
            Assert.IsFalse(secondRemoved);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNullKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Remove(null);
        }

        [TestMethod]
        public void TestFindSingleItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            int found = hashTable.Find("mnop");
            Assert.AreEqual(15, found);
        }

        [TestMethod]
        public void TestFindManyItems()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            Assert.AreEqual(15, hashTable.Find("mnop"));
            Assert.AreEqual(3, hashTable.Find("abc"));
            Assert.AreEqual(5, hashTable.Find("def"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindNonexistingKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            Assert.AreEqual(15, hashTable.Find("mnop"));

            hashTable.Find("zzz");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindNullKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Find(null);
        }

        [TestMethod]
        public void TestClear()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            hashTable.Clear();

            Assert.AreEqual(0, hashTable.Count);
            Assert.AreEqual(0, hashTable.Keys.Length);
        }

        [TestMethod]
        public void TestIndexerGetter()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            Assert.AreEqual(3, hashTable["abc"]);
            Assert.AreEqual(5, hashTable["def"]);
            Assert.AreEqual(4561, hashTable["jkl"]);
        }

        [TestMethod]
        public void TestIndexerGetterNonexistingKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            int invalid = hashTable["zzz"];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIndexerGetterNullKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            string key = null;
            int invalid = hashTable[key];
        }

        [TestMethod]
        public void TestIndexerSetter()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("abc", 3);
            hashTable.Add("def", 5);
            hashTable.Add("ghi", 45213214);
            hashTable.Add("jkl", 4561);
            hashTable.Add("mnop", 15);

            hashTable["zzz"] = 50;
            Assert.AreEqual(6, hashTable.Count);
            Assert.IsTrue(hashTable.Keys.Contains("zzz"));
            Assert.AreEqual(50, hashTable["zzz"]);
        }
    }
}
