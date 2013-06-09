using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LongestSubsequenceOfEqualNumbersTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestLongestSubsequenceNull()
    {
        List<int> sequence = null;

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestLongestSubsequenceEmptyList()
    {
        List<int> sequence = new List<int>();

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
    }

    [TestMethod]
    public void TestLongestSubsequenceSingleElement()
    {
        List<int> sequence = new List<int>() { 1 };

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
        List<int> expected = new List<int>() { 1 };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestLongestSubsequenceSingleMatch()
    {
        List<int> sequence = new List<int>() { 1, 2, 5, 5, 5, 5, 5, 5, 4, 7, 8, 9, 1, 7, 5, 6, 4 };

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
        List<int> expected = new List<int>() { 5, 5, 5, 5, 5, 5 };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestLongestSubsequenceManyMatchesSingleLongest()
    {
        List<int> sequence = new List<int>() { 1, 2, 5, 5, 5, 5, 5, 5, 4, 7, 8, 9, 1, 5, 5, 5, 5, 5, 5, 5, 8, 7 };

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
        List<int> expected = new List<int>() { 5, 5, 5, 5, 5, 5, 5 };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestLongestSubsequenceTwoSequences()
    {
        List<int> sequence = new List<int>() { 1, 3, 3, 3, 3, 4, 1, 2, 6, 6, 6, 6, 2, 8 };

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);
        List<int> expected = new List<int>() { 3, 3, 3, 3 };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestLongestSubsequenceLengthOne()
    {
        List<int> sequence = new List<int>() { 1, 2, 5, 6, 1, 2, 4, 7, 8, 1, 2, 3, 5, 4, 9, 4 };

        List<int> actual = LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(sequence);

        // When there is no sequence longer than 1, the method must return the first sequence of length 1 (the first element)
        List<int> expected = new List<int>() { 1 };

        CollectionAssert.AreEqual(expected, actual);
    }
}