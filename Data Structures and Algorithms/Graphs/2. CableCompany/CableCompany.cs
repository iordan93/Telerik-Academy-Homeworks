//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Wintellect.PowerCollections;

//public class CableCompany
//{
//    public static void Main()
//    {
//        // http://cgm.cs.mcgill.ca/~hagha/topic28/mst.gif
//        StreamReader input = new StreamReader("../../input.txt");
//        Console.SetIn(input);

//        List<string[]> edgesInfo = new List<string[]>();
//        Dictionary<char, Node<char>> nodes = new Dictionary<char, Node<char>>();

//        string line = Console.ReadLine();
//        while (line != null)
//        {
//            string[] parts = line.Split(' ');
//            edgesInfo.Add(parts);

//            AddNodes(parts, nodes);

//            line = Console.ReadLine();
//        }

//        MultiDictionary<Node<char>, Edge<char>> graph = GenerateGraph(edgesInfo, nodes);

//        GenerateMinimalSpanningTree(graph);
//    }

//    private static void AddNodes(string[] parts, Dictionary<char, Node<char>> nodes)
//    {
//        if (!nodes.ContainsKey(parts[0][0]))
//        {
//            nodes[parts[0][0]] = new Node<char>(parts[0][0]);
//        }

//        if (!nodes.ContainsKey(parts[1][0]))
//        {
//            nodes[parts[1][0]] = new Node<char>(parts[1][0]);
//        }
//    }

//    private static MultiDictionary<Node<char>, Edge<char>> GenerateGraph(List<string[]> edgesInfo, Dictionary<char, Node<char>> nodes)
//    {
//        MultiDictionary<Node<char>, Edge<char>> graph = new MultiDictionary<Node<char>, Edge<char>>(false);

//        for (int i = 0; i < edgesInfo.Count; i++)
//        {
//            string[] current = edgesInfo[i];
//            graph[nodes[current[0][0]]].Add(new Edge<char>(nodes[current[0][0]], nodes[current[1][0]], int.Parse(current[2])));
//            graph[nodes[current[1][0]]].Add(new Edge<char>(nodes[current[1][0]], nodes[current[0][0]], int.Parse(current[2])));
//        }

//        return graph;
//    }

//    private static void GenerateMinimalSpanningTree(MultiDictionary<Node<char>, Edge<char>> graph)
//    {
//        HashSet<char> minimalSpanningTree = new HashSet<char>();
//        Node<char> firstNode = graph.First().Key;

//        PriorityQueue<Edge<char>> priorityQueue = new PriorityQueue<Edge<char>>();

//        int sum = Traverse(graph, firstNode, minimalSpanningTree, priorityQueue);

//        Console.WriteLine(string.Join(" -> ", minimalSpanningTree));
//        Console.WriteLine("The minimum cabling is {0} m.", sum);
//    }

//    private static int Traverse(
//        MultiDictionary<Node<char>, Edge<char>> graph,
//        Node<char> start,
//        HashSet<char> minimalSpanningTree,
//        PriorityQueue<Edge<char>> priorityQueue)
//    {
//        int sum = 0;
//        minimalSpanningTree.Add(start.Value);

//        foreach (var item in graph[start])
//        {
//            priorityQueue.Enqueue(item);
//        }

//        while (priorityQueue.Count > 0)
//        {
//            Edge<char> current = priorityQueue.Dequeue();

//            if (minimalSpanningTree.Contains(current.EndNode.Value))
//            {
//                continue;
//            }

//            foreach (var item in graph[current.EndNode])
//            {
//                priorityQueue.Enqueue(item);
//            }

//            minimalSpanningTree.Add(current.EndNode.Value);
//            sum += current.Distance;
//        }

//        return sum;
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _05.MinimalSpaningTree
{
    class Program
    {
        class Node
        {
            public string Value { get; set; }

            public Node(string value)
            {
                this.Value = value;
            }
        }

        class Edge : IComparable
        {
            public Node Destination { get; set; }
            public Node Source { get; set; }
            public int Weight { get; set; }

            public Edge(Node source, Node destination, int weight)
            {
                this.Source = source;
                this.Destination = destination;
                this.Weight = weight;
            }

            public int CompareTo(object obj)
            {
                return this.Weight.CompareTo((obj as Edge).Weight);
            }
        }
        static void Main(string[] args)
        {
            //Test INPUT
            //            A B 3
            //A F 2
            //B C 17
            //B D 16
            //C D 8
            //C I 18
            //D E 11
            //D I 4
            //E F 1
            //E G 6
            //E H 5
            //E I 10
            //F G 7
            //G H 15
            //H I 12
            //H J 13
            //I J 9
            //mstSIZE = 48

            //            A C 5
            //A B 4
            //A D 9
            //B D 2
            //C D 20
            //C E 7
            //D E 8
            //E F 12
            //mstSIZE =30 this one is from presentation

            Dictionary<Node, List<Edge>> map = new Dictionary<Node, List<Edge>>();
            Dictionary<string, Node> allNodes = new Dictionary<string, Node>();
            string input = Console.ReadLine();

            while (input != String.Empty)
            {
                string[] splittedInput = input.Split(' ');
                if (!allNodes.ContainsKey(splittedInput[0]))
                {
                    allNodes[splittedInput[0]] = new Node(splittedInput[0]);
                }
                if (!allNodes.ContainsKey(splittedInput[1]))
                {
                    allNodes[splittedInput[1]] = new Node(splittedInput[1]);
                }
                if (!map.ContainsKey(allNodes[splittedInput[0]]))
                {
                    map[allNodes[splittedInput[0]]] = new List<Edge>();
                }
                if (!map.ContainsKey(allNodes[splittedInput[1]]))
                {
                    map[allNodes[splittedInput[1]]] = new List<Edge>();
                }

                map[allNodes[splittedInput[0]]].Add(new Edge(allNodes[splittedInput[0]], allNodes[splittedInput[1]], int.Parse(splittedInput[2])));
                map[allNodes[splittedInput[1]]].Add(new Edge(allNodes[splittedInput[1]], allNodes[splittedInput[0]], int.Parse(splittedInput[2])));
                input = Console.ReadLine();
            }

            Dictionary<Node, List<Edge>> MST = new Dictionary<Node, List<Edge>>();

            var item = map.First().Key;
            OrderedBag<Edge> bag = new OrderedBag<Edge>();
            while (item != null)
            {
                if (!MST.ContainsKey(item))
                {
                    MST[item] = new List<Edge>();
                }
                else
                {
                    break;
                }

                foreach (var edge in map[item])
                {
                    bag.Add(edge);
                }
                while (bag.Count != 0)
                {
                    Edge currentEdge = bag.RemoveFirst();
                    if (!MST.ContainsKey(currentEdge.Destination))
                    {
                        MST[currentEdge.Source].Add(currentEdge);
                        item = currentEdge.Destination;
                        break;
                    }
                }
            }

            int sizeMST = 0;
            foreach (var node in MST)
            {
                Console.WriteLine("{0}", node.Key.Value);
                foreach (var edge in node.Value)
                {
                    Console.WriteLine("{2}-> Edge: {0} Destination: {1}", edge.Destination.Value, edge.Weight, node.Key.Value);
                    sizeMST += edge.Weight;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Size of MST is: {0}", sizeMST);
        }
    }
}

