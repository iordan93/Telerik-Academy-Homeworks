using System;
using Wintellect.PowerCollections;

public class PriorityQueue<T> where T : IComparable<T>
{
    private OrderedBag<T> priorityQueue;

    public PriorityQueue()
    {
        this.priorityQueue = new OrderedBag<T>();
    }

    public int Count
    {
        get
        {
            return this.priorityQueue.Count;
        }
    }

    public void Enqueue(T element)
    {
        this.priorityQueue.Add(element);
    }

    public T Peek()
    {
        return this.priorityQueue[0];
    }

    public T Dequeue()
    {
        return this.priorityQueue.RemoveFirst();
    }
}
