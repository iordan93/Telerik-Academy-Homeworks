using System;

public class Product
{
    public Product(string name, int weight, int cost)
    {
        this.Name = name;
        this.Weight = weight;
        this.Cost = cost;
    }

    public string Name { get; set; }

    public int Weight { get; set; }

    public int Cost { get; set; }
}