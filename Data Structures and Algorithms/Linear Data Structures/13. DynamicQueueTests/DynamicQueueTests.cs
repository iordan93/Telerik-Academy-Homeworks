using System;
using System.Linq;
using DynamicQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class DynamicQueueTests
{
    [TestMethod]
    public void TestDynamicQueueConstructor()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();

        Assert.IsNotNull(queue);
        Assert.AreEqual(0, queue.Count);
    }

    [TestMethod]
    public void TestDynamicQueueEnqueueSingleValue()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        queue.Enqueue(10);

        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(10, queue.First());
    }

    [TestMethod]
    public void TestDynamicQueueEnqueueManyValues()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        queue.Enqueue(15);
        queue.Enqueue(4512);
        queue.Enqueue(2545);
        queue.Enqueue(546845);
        queue.Enqueue(5429);

        Assert.AreEqual(5, queue.Count);
        Assert.AreEqual(15, queue.First());
        Assert.AreEqual(4512, queue.Skip(1).First());
        Assert.AreEqual(2545, queue.Skip(2).First());
        Assert.AreEqual(546845, queue.Skip(3).First());
        Assert.AreEqual(5429, queue.Skip(4).First());
    }

    [TestMethod]
    public void TestDynamicQueueDequeueSingleValue()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        
        queue.Enqueue(10);
        int dequeuedNumber = queue.Dequeue();
        
        Assert.AreEqual(0, queue.Count);
        Assert.AreEqual(10, dequeuedNumber);
    }

    [TestMethod]
    public void TestDynamicQueueDequeueManyValues()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        queue.Enqueue(15);
        queue.Enqueue(4512);
        queue.Enqueue(2545);
        queue.Enqueue(546845);
        queue.Enqueue(5429);

        int queueCount = queue.Count;
        for (int i = 0; i < queueCount; i++)
        {
            int firstItem = queue.First();
            int dequeuedNumber = queue.Dequeue();
            Assert.AreEqual(dequeuedNumber, firstItem);
        }

        Assert.AreEqual(0, queue.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestDynamicQueueDequeueEmpty()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        queue.Dequeue();
    }

    [TestMethod]
    public void TestDynamicQueuePeek()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        int firstNumber = queue.Peek();

        Assert.AreEqual(3, queue.Count);
        Assert.AreEqual(10, firstNumber);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestDynamicQueuePeekEmpty()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();
        queue.Peek();
    }

    [TestMethod]
    public void TestDynamicQueueClear()
    {
        DynamicQueue<int> queue = new DynamicQueue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Clear();

        Assert.AreEqual(0, queue.Count);
    }
}