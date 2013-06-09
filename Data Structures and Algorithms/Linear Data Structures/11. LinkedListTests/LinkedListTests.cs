using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestLinkedListConstructor()
    {
        LinkedList<int> list = new LinkedList<int>();

        Assert.IsNotNull(list);
        Assert.IsInstanceOfType(list, typeof(LinkedList<int>));
    }

    [TestMethod]
    public void TestLinkedListAddSingleItem()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddFirst(15);

        Assert.AreEqual(15, list.First.Value);
        Assert.AreEqual(15, list.Last.Value);
        Assert.IsNull(list.First.NextItem);
    }

    [TestMethod]
    public void TestLinkedListAddManyItems()
    {
        LinkedList<string> list = new LinkedList<string>();

        list.AddFirst("some text");
        list.AddFirst("some more text");
        list.AddFirst("that should be enough");

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("that should be enough", list.First.Value);
        Assert.AreEqual("some more text", list.First.NextItem.Value);
        Assert.AreEqual("some text", list.First.NextItem.NextItem.Value);

        Assert.AreEqual("some text", list.Last.Value);
        Assert.AreEqual("some more text", list.Last.PreviousItem.Value);
        Assert.AreEqual("that should be enough", list.Last.PreviousItem.PreviousItem.Value);
    }

    [TestMethod]
    public void TestLinkedListAddLastSingleItem()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(15);

        Assert.AreEqual(15, list.First.Value);
        Assert.AreEqual(15, list.Last.Value);
        Assert.IsNull(list.Last.PreviousItem);
    }

    [TestMethod]
    public void TestLinkedListAddLastManyItems()
    {
        LinkedList<string> list = new LinkedList<string>();

        list.AddLast("some text");
        list.AddLast("some more text");
        list.AddLast("that should be enough");

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("some text", list.First.Value);
        Assert.AreEqual("some more text", list.First.NextItem.Value);
        Assert.AreEqual("that should be enough", list.First.NextItem.NextItem.Value);

        Assert.AreEqual("that should be enough", list.Last.Value);
        Assert.AreEqual("some more text", list.Last.PreviousItem.Value);
        Assert.AreEqual("some text", list.Last.PreviousItem.PreviousItem.Value);
    }

    [TestMethod]
    public void TestLinkedListRemoveSingleItem()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddFirst(15);
        list.RemoveFirst();
        Assert.IsNull(list.First);
        Assert.IsNull(list.Last);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestLinkedListRemoveFromEmptyList()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.RemoveFirst();
    }

    [TestMethod]
    public void TestLinkedListRemoveFromFullList()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);
        list.RemoveFirst();

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(481356, list.First.Value);
        Assert.AreEqual(56, list.First.NextItem.Value);
        Assert.AreEqual(56, list.Last.Value);
    }

    [TestMethod]
    public void TestLinkedListRemoveManyTimes()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);
        list.RemoveFirst();
        list.RemoveFirst();

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(56, list.First.Value);
        Assert.AreEqual(56, list.Last.Value);
    }

    [TestMethod]
    public void TestLinkedListRemoveLastSingleItem()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(15);
        list.RemoveLast();
        Assert.IsNull(list.First);
        Assert.IsNull(list.Last);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestLinkedListRemoveLastFromEmptyList()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.RemoveLast();
    }

    [TestMethod]
    public void TestLinkedListRemoveLastFromFullList()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);
        list.RemoveLast();

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(35, list.First.Value);
        Assert.AreEqual(481356, list.First.NextItem.Value);
        Assert.AreEqual(481356, list.Last.Value);
    }

    [TestMethod]
    public void TestLinkedListRemoveLastManyTimes()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);
        list.RemoveLast();
        list.RemoveLast();

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(35, list.First.Value);
        Assert.AreEqual(35, list.Last.Value);
    }

    [TestMethod]
    public void TestLinkedListFindExistingItem()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);

        ListItem<int> foundItem = list.Find(481356);

        Assert.AreEqual(481356, foundItem.Value);

        // Check chaining - the node must not be unlinked
        Assert.IsNotNull(foundItem.NextItem);
        Assert.IsNotNull(foundItem.PreviousItem);
        Assert.AreEqual(list.First, foundItem.PreviousItem);
        Assert.AreEqual(list.Last, foundItem.NextItem);
    }

    [TestMethod]
    public void TestLinkedListFindNonexistingItem()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(5);

        ListItem<int> foundItem = list.Find(56);

        Assert.IsNull(foundItem);
    }

    [TestMethod]
    public void TestLinkedListFindLastExistingItem()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(56);

        ListItem<int> foundItem = list.FindLast(481356);

        Assert.AreEqual(481356, foundItem.Value);

        // Check chaining - the node must not be unlinked
        Assert.IsNotNull(foundItem.NextItem);
        Assert.IsNotNull(foundItem.PreviousItem);
        Assert.AreEqual(list.First, foundItem.PreviousItem);
        Assert.AreEqual(list.Last, foundItem.NextItem);
    }

    [TestMethod]
    public void TestLinkedListFindLastNonexistingItem()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(35);
        list.AddLast(481356);
        list.AddLast(5);

        ListItem<int> foundItem = list.FindLast(56);

        Assert.IsNull(foundItem);
    }

    [TestMethod]
    public void TestLinkedListClear()
    {
        Random random = new Random();
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < 100; i++)
        {
            list.AddLast(random.Next());
        }

        Assert.AreEqual(100, list.Count);

        list.Clear();
        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.First);
        Assert.IsNull(list.Last);
    }

    [TestMethod]
    public void TestLinkedListEnumerator()
    {
        Random random = new Random();
        LinkedList<int> list = new LinkedList<int>();
        System.Collections.Generic.List<int> originalList = new System.Collections.Generic.List<int>();

        for (int i = 0; i < 100; i++)
        {
            list.AddLast(random.Next());
        }
        
        foreach (var item in list)
        {
            originalList.Add(item);
        }
        
        ListItem<int> current = list.First;
        for (int i = 0; i < originalList.Count; i++)
        {
            Assert.AreEqual(current.Value, originalList[i]);
            current = current.NextItem;
        }
    }
}
