using System;

public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
{
    public Node(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }

    public int CompareTo(Node<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override bool Equals(object obj)
    {
        return this.Value.Equals((obj as Node<T>).Value);
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