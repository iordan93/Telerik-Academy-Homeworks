using System;
using System.Collections.Generic;
using System.IO;

public class KnapsackProblem
{
    public static void Main()
    {
        StreamReader input = new StreamReader("../../input.txt");
        Console.SetIn(input);

        int knapsackCapacity = int.Parse(Console.ReadLine());
        int numberOfProducts = int.Parse(Console.ReadLine());

        List<Product> products = new List<Product>();
        List<int> weights = new List<int>();
        List<int> costs = new List<int>();

        for (int i = 0; i < numberOfProducts; i++)
        {
            string[] productParts = Console.ReadLine().Split(' ');
            Product product = new Product(productParts[0], int.Parse(productParts[1]), int.Parse(productParts[2]));
            products.Add(product);
            weights.Add(int.Parse(productParts[1]));
            costs.Add(int.Parse(productParts[2]));
        }

        int maximalCost = SolveKnapsackProblem(products, costs, weights, numberOfProducts, knapsackCapacity);
        Console.WriteLine("Maximal cost of items: {0}.", maximalCost);
    }

    private static int SolveKnapsackProblem(List<Product> products, List<int> costs, List<int> weights, int numberOfProducts, int knapsackCapacity)
    {
        int[,] valuesTable = new int[numberOfProducts, knapsackCapacity];
        int[,] keptItemsTable = new int[numberOfProducts, knapsackCapacity];
        
        // The basic case consists of 0 products
        for (int w = 0; w < knapsackCapacity; w++)
        {
            valuesTable[0, w] = 0;
        }

        for (int row = 1; row < numberOfProducts; row++)
        {
            for (int col = 0; col < knapsackCapacity; col++)
            {
                if (weights[row] <= col && costs[row] + valuesTable[row - 1, col - weights[row]] > valuesTable[row - 1, col])
                {
                    valuesTable[row, col] = costs[row] + valuesTable[row - 1, col - weights[row]];
                    keptItemsTable[row, col] = 1;
                }
                else
                {
                    valuesTable[row, col] = valuesTable[row - 1, col];
                    keptItemsTable[row, col] = 0;
                }
            }
        }

        int currentProductIndex = knapsackCapacity - 1;
        for (int i = numberOfProducts - 1; i >= 1; i--)
        {
            if (keptItemsTable[i, currentProductIndex] == 1)
            {
                Console.WriteLine(products[i].Name);
                currentProductIndex -= weights[i];
            }
        }

        return valuesTable[numberOfProducts - 1, knapsackCapacity - 1];
    }
}