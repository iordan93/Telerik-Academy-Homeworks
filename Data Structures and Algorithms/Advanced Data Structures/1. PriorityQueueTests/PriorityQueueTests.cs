namespace _1.PriorityQueueTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _1.PriorityQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestPriorityQueueConstructor()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            Assert.IsNotNull(priorityQueue);
            Assert.IsInstanceOfType(priorityQueue, typeof(PriorityQueue<int>));
        }

        [TestMethod]
        public void TestEnqueueAndDequeueSingleItem()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(5);

            Assert.AreEqual(1, priorityQueue.Count);
            Assert.AreEqual(5, priorityQueue.Dequeue());
        }

        [TestMethod]
        public void TestEnqueueAndDequeueManyItemsOrdered()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(50000);
            priorityQueue.Enqueue(5000);
            priorityQueue.Enqueue(500);
            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(5);

            Assert.AreEqual(5, priorityQueue.Count);
            Assert.AreEqual(50000, priorityQueue.First());
            Assert.AreEqual(5000, priorityQueue.Skip(1).First());
            Assert.AreEqual(500, priorityQueue.Skip(2).First());
            Assert.AreEqual(50, priorityQueue.Skip(3).First());
            Assert.AreEqual(5, priorityQueue.Skip(4).First());
        }

        [TestMethod]
        public void TestEnqueueAndDequeueEvenNumberOfItemsReversed()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(500);
            priorityQueue.Enqueue(5000);

            Assert.AreEqual(4, priorityQueue.Count);
            Assert.AreEqual(5000, priorityQueue.Dequeue());
            Assert.AreEqual(500, priorityQueue.Dequeue());
            Assert.AreEqual(50, priorityQueue.Dequeue());
            Assert.AreEqual(5, priorityQueue.Dequeue());
        }

        [TestMethod]
        public void TestEnqueueAndDequeueOddNumberOfItemsReversed()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(500);
            priorityQueue.Enqueue(5000);
            priorityQueue.Enqueue(50000);
            priorityQueue.Enqueue(500000);
            priorityQueue.Enqueue(5000000);

            Assert.AreEqual(7, priorityQueue.Count);
            Assert.AreEqual(5000000, priorityQueue.Dequeue());
            Assert.AreEqual(500000, priorityQueue.Dequeue());
            Assert.AreEqual(50000, priorityQueue.Dequeue());
            Assert.AreEqual(5000, priorityQueue.Dequeue());
            Assert.AreEqual(500, priorityQueue.Dequeue());
            Assert.AreEqual(50, priorityQueue.Dequeue());
            Assert.AreEqual(5, priorityQueue.Dequeue());
        }

        [TestMethod]
        public void TestEnqueueAndDequeueOddNumberOfItemsRandom()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(5000000);
            priorityQueue.Enqueue(500);
            priorityQueue.Enqueue(500000);
            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(50000);
            priorityQueue.Enqueue(5000);

            Assert.AreEqual(7, priorityQueue.Count);
            Assert.AreEqual(5000000, priorityQueue.Dequeue());
            Assert.AreEqual(500000, priorityQueue.Dequeue());
            Assert.AreEqual(50000, priorityQueue.Dequeue());
            Assert.AreEqual(5000, priorityQueue.Dequeue());
            Assert.AreEqual(500, priorityQueue.Dequeue());
            Assert.AreEqual(50, priorityQueue.Dequeue());
            Assert.AreEqual(5, priorityQueue.Dequeue());
        }

        [TestMethod]
        [Timeout(5000)]
        public void TestEnqueueAndDequeueManyItems()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            Random generator = new Random();
            List<int> output = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                priorityQueue.Enqueue(generator.Next());
            }

            for (int i = 0; i < 1000000; i++)
            {
                output.Add(priorityQueue.Dequeue());
            }

            Assert.IsTrue(IsSortedDescending(output));
        }

        private static bool IsSortedDescending(List<int> output)
        {
            for (int i = 0; i < output.Count - 1; i++)
            {
                if (output[i] < output[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
