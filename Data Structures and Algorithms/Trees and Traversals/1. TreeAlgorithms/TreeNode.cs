namespace TreeAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            this.Value = value;
            this.Children = children;
        }

        public TreeNode(T value)
            : this(value, new List<TreeNode<T>>())
        {
        }

        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; }
    }
}
