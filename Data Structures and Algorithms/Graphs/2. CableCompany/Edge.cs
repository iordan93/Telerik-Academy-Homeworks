using System;

public class Edge<T> : IComparable<Edge<T>> where T : IComparable<T>
{
    public Edge(Node<T> startNode, Node<T> endNode, int distance)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Distance = distance;
    }

    public Node<T> StartNode { get; set; }

    public Node<T> EndNode { get; set; }

    public int Distance { get; set; }

    public int CompareTo(Edge<T> other)
    {
        return this.Distance.CompareTo(other.Distance);
    }

    public override string ToString()
    {
        return string.Format("{0} - {1}", this.EndNode, this.Distance);
    }
}
