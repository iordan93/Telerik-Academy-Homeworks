namespace MaximalPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximalPath
    {
        private static List<Node<long>> longestPathNodes = new List<Node<long>>();
        private static long maxSum = long.MinValue;
        private static List<Node<long>> currentPath = new List<Node<long>>();

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            int numberOfLeaves = int.Parse(Console.ReadLine());
            Dictionary<long, Node<long>> tree = new Dictionary<long, Node<long>>();
            for (int i = 0; i < numberOfLeaves - 1; i++)
            {
                string[] line = Console.ReadLine().Split(new string[] { "(", " <- ", ")" }, StringSplitOptions.RemoveEmptyEntries);

                Node<long> firstNode = new Node<long>(long.Parse(line[0]));
                if (!tree.Keys.Contains(firstNode.Value))
                {
                    tree[firstNode.Value] = firstNode;
                }

                Node<long> secondNode = new Node<long>(long.Parse(line[1]));
                if (!tree.Keys.Contains(secondNode.Value))
                {
                    tree[secondNode.Value] = secondNode;
                }

                if (tree[firstNode.Value].Neighbours == null)
                {
                    tree[firstNode.Value].Neighbours = new List<Node<long>>();
                }

                tree[firstNode.Value].Neighbours.Add(tree[secondNode.Value]);
                tree[secondNode.Value].HasParent = true;
            }

            var root = GetRoot(tree);

            GetMaximalPath(tree, root, 0);
            longestPathNodes.Add(root);
            foreach (var item in longestPathNodes)
            {
                item.IsVisited = true;
            }

            long halfSum = maxSum + root.Value;
            maxSum = 0;
            GetMaximalPath(tree, root, 0);
            
            Console.WriteLine(halfSum + maxSum);
        }

        private static Node<long> GetRoot(Dictionary<long, Node<long>> tree)
        {
            foreach (var kvp in tree)
            {
                if (!kvp.Value.HasParent)
                {
                    return kvp.Value;
                }
            }

            throw new ArgumentException("The tree has no root.");
        }

        private static void GetMaximalPath(Dictionary<long, Node<long>> tree, Node<long> startNode, long currentSum)
        {
            foreach (var neighbour in startNode.Neighbours)
            {
                if (!neighbour.IsVisited)
                {
                    currentPath.Add(neighbour);
                    currentSum += neighbour.Value;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        longestPathNodes.Clear();
                        longestPathNodes.AddRange(currentPath);
                    }

                    GetMaximalPath(tree, neighbour, currentSum);
                    currentPath.Remove(currentPath.Last());
                    currentSum -= neighbour.Value;
                }
            }
        }
    }

    public class Node<T>
    {
        public Node(T value, List<Node<T>> neighbours, bool hasParent)
        {
            this.Value = value;
            this.Neighbours = neighbours;
            this.HasParent = hasParent;
        }

        public Node(T value)
            : this(value, new List<Node<T>>(), false)
        {
        }

        public T Value { get; set; }

        public List<Node<T>> Neighbours { get; set; }

        public bool HasParent { get; set; }

        public bool IsVisited { get; set; }

        public override bool Equals(object obj)
        {
            Node<T> node = obj as Node<T>;
            if (node != null)
            {
                return this.Value.Equals(node.Value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
