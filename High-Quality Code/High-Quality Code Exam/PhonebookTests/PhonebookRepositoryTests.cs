namespace PhonebookTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook;

    [TestClass]
    public class PhonebookRepositoryTests
    {
        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddSinglePhoneTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool added = repository.AddPhone("Frank", new List<string> { "0888888888" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repository.Entries.Count);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddSinglePhoneEmptyNameTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool added = repository.AddPhone(string.Empty, new List<string> { "0888888888" });

            // True because all data will always be valid
            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repository.Entries.Count);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddSinglePhoneEmptyPhonesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool added = repository.AddPhone(string.Empty, new List<string>());

            // True because all data will always be valid
            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repository.Entries.Count);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddSingleItemManyPhonesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool added = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repository.Entries.Count);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddManyItemsTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool secondAdded = repository.AddPhone("Maria", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsTrue(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.AreEqual(3, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(repository.Entries);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddManyItemsDuplicatePhonesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "0888888888", "0888888888", "0888888888", "0888888888" });
            bool secondAdded = repository.AddPhone("Maria", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsTrue(secondAdded);
            Assert.IsTrue(thirdAdded);

            string expected = "[Frank: 0888888888]";
            string actual = repository.Entries.First().ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(3, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(repository.Entries);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void MergeSingleItemTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool secondAdded = repository.AddPhone("Frank", new List<string> { "(02) 00 55", "00359 (888) 22 22 11" });
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsFalse(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.AreEqual(2, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(repository.Entries);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void MergeSingleItemCheckDuplicatesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool secondAdded = repository.AddPhone("Frank", new List<string> { "(02) 00 55", "00359 (888) 41-80-12" });
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsFalse(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.AreEqual(2, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(repository.Entries);
            string actual = repository.Entries.First().ToString();

            // 00359 (888) 41-80-12 should not be added as it is a duplicate
            // Also confirms that the numbers are saved in their original form
            string expected = "[Frank: (02) 00 55, (02) 981 22 33, 00359 (888) 41-80-12, 0888888888]";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void MergeSingleItemAllDuplicatesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool secondAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsFalse(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.AreEqual(2, repository.Entries.Count);
            string actual = repository.Entries.First().ToString();
            string expected = "[Frank: (02) 981 22 33, 00359 (888) 41-80-12, 0888888888]";

            Assert.AreEqual(expected, actual);
            CollectionAssert.AllItemsAreUnique(repository.Entries);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void MergeAddingTheSameObjectsTwiceTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            string name = "Frank";
            List<string> phones = new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" };
            bool firstAdded = repository.AddPhone(name, phones);
            bool secondAdded = repository.AddPhone(name, phones);
            bool thirdAdded = repository.AddPhone("Josh", new List<string> { "00359 (888) 41-80-12" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsFalse(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.AreEqual(2, repository.Entries.Count);
            string actual = repository.Entries.First().ToString();
            string expected = "[Frank: (02) 981 22 33, 00359 (888) 41-80-12, 0888888888]";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("AddPhoneTests")]
        public void AddAndMergeManyItemsTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool secondAdded = repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool thirdAdded = repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            bool fourthAdded = repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool fifthAdded = repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool sixthAdded = repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool seventhAdded = repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            bool eighthAdded = repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            bool ninthAdded = repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            bool tenthAdded = repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(firstAdded);
            Assert.IsTrue(secondAdded);
            Assert.IsTrue(thirdAdded);
            Assert.IsFalse(fourthAdded);
            Assert.IsFalse(fifthAdded);
            Assert.IsFalse(sixthAdded);
            Assert.IsFalse(seventhAdded);
            Assert.IsFalse(eighthAdded);
            Assert.IsFalse(ninthAdded);
            Assert.IsTrue(tenthAdded);

            Assert.AreEqual(4, repository.Entries.Count);

            // Frank is first and Peter is third (and has a total of six phone numbers)
            string actualFrank = repository.Entries.First().ToString();
            string expectedFrank = "[Frank: (02) 981 22 33, 00359 (888) 41-80-12, 0888888888]";
            string actualPeter = repository.Entries.Skip(2).First().ToString();
            string expectedPeter = "[Peter: (02) 981 22 33, 00359 (854) 11-22-22, 00359 (888) 41-80-12, 088123, 0888888888]";

            Assert.AreEqual(expectedFrank, actualFrank);
            Assert.AreEqual(expectedPeter, actualPeter);
        }

        [TestMethod]
        [TestCategory("ChangePhoneTests")]
        public void ChangeSinglePhoneTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool added = repository.AddPhone("Frank", new List<string> { "0888888888" });
            int changedPhonesCount = repository.ChangePhone("0888888888", "0999999999");

            Assert.IsNotNull(repository.Entries);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repository.Entries.Count);
            Assert.AreEqual(1, changedPhonesCount);
        }

        [TestMethod]
        [TestCategory("ChangePhoneTests")]
        public void ChangeSinglePhoneManyItemsTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            bool firstAdded = repository.AddPhone("Frank", new List<string> { "0888888888" });
            bool secondAdded = repository.AddPhone("Anna", new List<string> { "0888888888" });
            bool thidAdded = repository.AddPhone("Peter", new List<string> { "0888888888" });
            bool fourthAdded = repository.AddPhone("Michael", new List<string> { "0888888888" });
            bool fifthAdded = repository.AddPhone("Barry", new List<string> { "0888888888" });

            int changedPhonesCount = repository.ChangePhone("0888888888", "0999999999");

            Assert.IsNotNull(repository.Entries);
            Assert.AreEqual(5, repository.Entries.Count);
            Assert.AreEqual(5, changedPhonesCount);

            // Confirm the phone has changed at all places
            string expectedFrank = "[Frank: 0999999999]";
            string actualFrank = repository.Entries.First().ToString();
            string expectedBarry = "[Barry: 0999999999]";
            string actualBarry = repository.Entries.Skip(4).First().ToString();
            Assert.AreEqual(expectedFrank, actualFrank);
            Assert.AreEqual(expectedBarry, actualBarry);
        }

        [TestMethod]
        [TestCategory("ChangePhoneTests")]
        public void ChangeSinglePhoneNoMatchingItemsTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888" });
            repository.AddPhone("Anna", new List<string> { "0888888888" });
            repository.AddPhone("Peter", new List<string> { "0888888888" });
            repository.AddPhone("Michael", new List<string> { "0888888888" });
            repository.AddPhone("Barry", new List<string> { "0888888888" });

            int changedPhonesCount = repository.ChangePhone("0001", "0956");

            Assert.IsNotNull(repository.Entries);
            Assert.AreEqual(5, repository.Entries.Count);
            Assert.AreEqual(0, changedPhonesCount);
        }

        [TestMethod]
        [TestCategory("ChangePhoneTests")]
        public void ChangeSinglePhoneSingleMatchingAndSomeNotMatchingTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888" });
            repository.AddPhone("Anna", new List<string> { "08888" });
            repository.AddPhone("Peter", new List<string> { "(02) 524 45" });

            int changedPhonesCount = repository.ChangePhone("08888", "00359 (02) 22 22 22");

            Assert.AreEqual(3, repository.Entries.Count);
            Assert.AreEqual(1, changedPhonesCount);
            string expectedAnna = "[Anna: 00359 (02) 22 22 22]";
            string actualAnna = repository.Entries.Skip(1).First().ToString();
            string expectedPeter = "[Peter: (02) 524 45]";
            string actualPeter = repository.Entries.Skip(2).First().ToString();
            Assert.AreEqual(expectedAnna, actualAnna);
            Assert.AreEqual(expectedPeter, actualPeter);
        }

        [TestMethod]
        [TestCategory("ChangePhoneTests")]
        public void DoubleUpdateTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888" });
            repository.AddPhone("Anna", new List<string> { "08888" });
            repository.AddPhone("Peter", new List<string> { "(02) 524 45" });

            // First change
            int changedPhonesCount = repository.ChangePhone("08888", "00359 (02) 22 22 22");
            Assert.AreEqual(1, changedPhonesCount);
            string expectedAnna = "[Anna: 00359 (02) 22 22 22]";
            string actualAnna = repository.Entries.Skip(1).First().ToString();
            string expectedPeter = "[Peter: (02) 524 45]";
            string actualPeter = repository.Entries.Skip(2).First().ToString();
            Assert.AreEqual(expectedAnna, actualAnna);
            Assert.AreEqual(expectedPeter, actualPeter);

            // Second change - the result should be like the original one
            int changedAgainPhonesCount = repository.ChangePhone("00359 (02) 22 22 22", "08888");

            Assert.AreEqual(1, changedAgainPhonesCount);
            string expectedChangedAnna = "[Anna: 08888]";
            string actualChangedAnna = repository.Entries.Skip(1).First().ToString();
            string expectedChangedPeter = "[Peter: (02) 524 45]";
            string actualChangedPeter = repository.Entries.Skip(2).First().ToString();
            Assert.AreEqual(expectedChangedAnna, actualChangedAnna);
            Assert.AreEqual(expectedChangedPeter, actualChangedPeter);
        }

        [TestMethod]
        [TestCategory("ListEntriesTests")]
        public void ListAllAvailableEntriesAndCheckSortingTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });
            PhonebookEntry[] expected = repository.ListEntries(0, 4);

            Assert.AreEqual(4, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(expected);
            Assert.AreEqual(4, expected.Length);
        }

        [TestMethod]
        [TestCategory("ListEntriesTests")]
        public void ListSomeAvailableEntriesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });
            PhonebookEntry[] expected = repository.ListEntries(0, 2);

            Assert.AreEqual(4, repository.Entries.Count);
            CollectionAssert.AllItemsAreUnique(expected);
            Assert.AreEqual(2, expected.Length);
        }

        [TestMethod]
        [TestCategory("ListEntriesTests")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid start index or count.")]
        public void ListMoreThanAvailableEntriesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });
            repository.ListEntries(0, 200);
        }

        [TestMethod]
        [TestCategory("ListEntriesTests")]
        public void ListZeroEntriesTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });
            PhonebookEntry[] entries = repository.ListEntries(0, 0);
            Assert.AreEqual(0, entries.Length);
        }

        [TestMethod]
        [TestCategory("ListEntriesTests")]
        public void ListTwoEntriesNotStartingFromZeroTest()
        {
            PhonebookRepository repository = new PhonebookRepository();
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Frank", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Anna", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Frank", new List<string> { "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "0888888888", "(02) 981 22 33", "00359 (888) 41-80-12" });
            repository.AddPhone("Peter", new List<string> { "088123", "(02) 981 22 33", "00359 (854) 11-22-22" });
            repository.AddPhone("Maria", new List<string> { "00359 (854) 11-22-22" });
            PhonebookEntry[] entries = repository.ListEntries(2, 2);

            // Check that the elements are two and that they are the last two
            Assert.AreEqual(2, entries.Length);
            CollectionAssert.AllItemsAreUnique(entries);
            string actualFirst = entries.First().ToString();
            string expectedFirst = "[Maria: 00359 (854) 11-22-22]"; 
            string actualSecond = entries.Skip(1).First().ToString();
            string expectedSecond = "[Peter: (02) 981 22 33, 00359 (854) 11-22-22, 00359 (888) 41-80-12, 088123, 0888888888]";
            Assert.AreEqual(expectedFirst,actualFirst);
            Assert.AreEqual(expectedSecond,actualSecond);
        }
    }
}
