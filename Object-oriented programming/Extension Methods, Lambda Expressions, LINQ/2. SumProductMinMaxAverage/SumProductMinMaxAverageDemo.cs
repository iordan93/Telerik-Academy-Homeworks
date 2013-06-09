using System;
using System.Collections.Generic;
//using System.Linq;

class SumProductMinMaxAverageDemo
{
    static void Main()
    {
        List<int> myList = new List<int>();
        // 27! is the largest factorial (product of the list) that the decimal type can take
        for (int i = 1; i <= 27; i++)
        {
            myList.Add(i);
        }

        Console.WriteLine(myList.Sum());
        Console.WriteLine(myList.Product());
        Console.WriteLine(myList.Min());
        Console.WriteLine(myList.Max());
        Console.WriteLine(myList.Average());
    }
}