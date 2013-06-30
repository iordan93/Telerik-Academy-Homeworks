using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FriendsOfPesho
{
    public static void Main()
    {
        string[] nodesInfo = Console.ReadLine().Split(' ');
        int edgesCount = int.Parse(nodesInfo[1]);
        int hospitalsCount = int.Parse(nodesInfo[2]);

        string[] hospitalsInfo = Console.ReadLine().Split(' ');
        int[] hospitalIndices = new int[hospitalsCount];
        for (int i = 0; i < hospitalsCount; i++)
        {
            hospitalIndices[i] = int.Parse(hospitalsInfo[i]);
        }

        List<int[]> edges = new List<int[]>();

        Dictionary<int, Node<int>> nodes = GenerateNodes(edgesCount, edges);
        Dictionary<Node<int>, List<Edge<int>>> map = GenerateMap(edges, nodes);

        long minDistance = long.MaxValue;
        foreach (var hospital in hospitalIndices)
        {
            DijkstraDistanceAlgorithm(map, nodes[hospital]);

            long currentDistance = 0;

            foreach (var node in map)
            {
                if (!hospitalIndices.Contains(node.Key.Value))
                {
                    currentDistance += node.Key.DijkstraDistance;
                }
            }

            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
            }
        }

        Console.WriteLine(minDistance);
    }

    private static Dictionary<int, Node<int>> GenerateNodes(int edgesCount, IList<int[]> edges)
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();

        for (int i = 0; i < edgesCount; i++)
        {
            string[] edgeInfo = Console.ReadLine().Split(' ');
            int start = int.Parse(edgeInfo[0]);
            int end = int.Parse(edgeInfo[1]);
            int distance = int.Parse(edgeInfo[2]);
            edges.Add(new int[] { start, end, distance });

            if (!nodes.ContainsKey(start))
            {
                nodes[start] = new Node<int>(start);
            }

            if (!nodes.ContainsKey(end))
            {
                nodes[end] = new Node<int>(end);
            }
        }

        return nodes;
    }

    private static Dictionary<Node<int>, List<Edge<int>>> GenerateMap(IList<int[]> edges, Dictionary<int, Node<int>> nodes)
    {
        Dictionary<Node<int>, List<Edge<int>>> map = new Dictionary<Node<int>, List<Edge<int>>>();
        foreach (var edge in edges)
        {
            if (!map.ContainsKey(nodes[edge[0]]))
            {
                map[nodes[edge[0]]] = new List<Edge<int>>();
            }

            if (!map.ContainsKey(nodes[edge[1]]))
            {
                map[nodes[edge[1]]] = new List<Edge<int>>();
            }

            map[nodes[edge[0]]].Add(new Edge<int>(nodes[edge[1]], edge[2]));
            map[nodes[edge[1]]].Add(new Edge<int>(nodes[edge[0]], edge[2]));
        }

        return map;
    }

    private static void DijkstraDistanceAlgorithm(Dictionary<Node<int>, List<Edge<int>>> map, Node<int> source)
    {
        foreach (var node in map.Keys)
        {
            node.DijkstraDistance = int.MaxValue;
        }

        source.DijkstraDistance = 0;

        PriorityQueue<Node<int>> priorityQueue = new PriorityQueue<Node<int>>();
        foreach (var node in map.Keys)
        {
            priorityQueue.Enqueue(node);
        }

        while (priorityQueue.Count > 0)
        {
            Node<int> currentNode = priorityQueue.Peek();

            if (currentNode.DijkstraDistance == int.MaxValue)
            {
                break;
            }

            foreach (var neighbourEdge in map[currentNode])
            {
                int potDistance = currentNode.DijkstraDistance + neighbourEdge.Distance;

                if (potDistance < neighbourEdge.EndNode.DijkstraDistance)
                {
                    neighbourEdge.EndNode.DijkstraDistance = potDistance;
                    priorityQueue.Enqueue(new Node<int>(neighbourEdge.EndNode.Value, potDistance));
                }
            }

            priorityQueue.Dequeue();
        }
    }
}

public class Node<T> : IComparable<Node<T>>
{
    public Node(T value, int dijkstraDistance)
    {
        this.Value = value;
        this.DijkstraDistance = dijkstraDistance;
    }

    public Node(T value)
        : this(value, int.MaxValue)
    {
    }

    public T Value { get; set; }

    public int DijkstraDistance { get; set; }

    public int CompareTo(Node<T> other)
    {
        return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Node<T>);
    }

    public bool Equals(Node<T> other)
    {
        return this.Value.Equals(other.Value);
    }
}

public class Edge<T>
{
    public Edge(Node<T> endNode, int distance)
    {
        this.EndNode = endNode;
        this.Distance = distance;
    }

    public Edge(Node<T> endNode)
        : this(endNode, int.MaxValue)
    {
    }

    public Node<T> EndNode { get; set; }

    public int Distance { get; set; }
}

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