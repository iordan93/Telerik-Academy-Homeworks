namespace TreeAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeAlgorithms
    {
        public static void Main()
        {
            TreeNode<int>[] tree = InitializeTree();
            try
            {
                TreeNode<int> root = GetRoot(tree);
                Console.WriteLine("The root of the tree is {0}.", root.Value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The tree has no root.");
            }

            TreeNode<int>[] leaves = GetLeaves(tree);
            Console.Write("The leaves of the tree are ");
            for (int i = 0; i < leaves.Length; i++)
            {
                Console.Write(leaves[i].Value);
                Console.Write(i == leaves.Length - 1 ? "." + Environment.NewLine : ", ");
            }

            TreeNode<int>[] middleNodes = GetMiddleNodes(tree);
            Console.Write("The middle nodes of the tree are ");
            for (int i = 0; i < middleNodes.Length; i++)
            {
                Console.Write(middleNodes[i].Value);
                Console.Write(i == middleNodes.Length - 1 ? "." + Environment.NewLine : ", ");
            }

            int sum = 9;
            int pathsWithSumThree = GetPathsWithSum(GetRoot(tree), sum, GetRoot(tree).Value, new List<int>(), new List<List<int>>());
            Console.WriteLine("There are {0} paths with sum {1}.", pathsWithSumThree, sum);

            int subtreesSum = GetSubtreesWithSum(GetRoot(tree));
            Console.WriteLine("The subtree starting from the root (e. g. the entire tree) has sum {0}.", subtreesSum);
        }

        public static TreeNode<int>[] InitializeTree()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            TreeNode<int>[] tree = new TreeNode<int>[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                tree[i] = new TreeNode<int>(i);
            }

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string input = Console.ReadLine();
                string[] nodePair = input.Split(' ');
                int parent = int.Parse(nodePair[0]);
                int child = int.Parse(nodePair[1]);
                tree[parent].Children.Add(tree[child]);
            }

            return tree;
        }

        public static TreeNode<int> GetRoot(TreeNode<int>[] tree)
        {
            bool[] hasParent = GetParents(tree);
            for (int i = 0; i < tree.Length; i++)
            {
                if (!hasParent[i])
                {
                    return tree[i];
                }
            }

            throw new ArgumentException("The tree has no root.");
        }

        public static TreeNode<int>[] GetLeaves(TreeNode<int>[] tree)
        {
            List<TreeNode<int>> leaves = new List<TreeNode<int>>();
            foreach (var node in tree)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves.ToArray();
        }

        public static TreeNode<int>[] GetMiddleNodes(TreeNode<int>[] tree)
        {
            List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();
            bool[] hasParent = GetParents(tree);
            foreach (var node in tree)
            {
                if (hasParent[node.Value] && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes.ToArray();
        }

        public static int GetLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }
            else
            {
                int longestPathLength = 0;
                foreach (var child in root.Children)
                {
                    longestPathLength = GetLongestPath(child);
                }

                return longestPathLength + 1;
            }
        }

        public static int GetPathsWithSum(TreeNode<int> root, int sum, int currentSum, List<int> currentPath, List<List<int>> paths)
        {
            foreach (var child in root.Children)
            {
                currentPath.Add(child.Value);
                currentSum += child.Value;
                if (currentSum == sum)
                {
                    paths.Add(currentPath);
                }

                GetPathsWithSum(child, sum, currentSum, currentPath, paths);
                currentPath.Remove(currentPath.Last());
                currentSum -= child.Value;
            }

            return paths.Count;
        }

        public static int GetSubtreesWithSum(TreeNode<int> root)
        {
            int currentSum = 0;
            if (root.Children.Count == 0)
            {
                currentSum += root.Value;
                return currentSum;
            }
            else
            {
                foreach (var child in root.Children)
                {
                    currentSum += GetSubtreesWithSum(child);
                }
            }

            return currentSum + root.Value;
        }

        private static bool[] GetParents(TreeNode<int>[] tree)
        {
            bool[] hasParent = new bool[tree.Length];
            foreach (var parent in tree)
            {
                foreach (var child in parent.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            return hasParent;
        }
    }
}