using System;
using System.Collections.Generic;
using System.Linq;

public class ShortestSequenceOfOperations
{
    public static void Main()
    {
        Console.Write("Enter the start number: ");
        int startNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the end number: ");
        int endNumber = int.Parse(Console.ReadLine());

        List<int> list = GetShortestSequenceOfOperationsBetween(startNumber, endNumber);
        Console.WriteLine(string.Join(" -> ", list));
    }

    public static List<int> GetShortestSequenceOfOperationsBetween(int firstNumber, int lastNumber)
    {
        Stack<int> sequence = new Stack<int>();

        int currentNumber = lastNumber;
        sequence.Push(currentNumber);

        // Work from the final number to the first in reverse
        // using a greedy approach - try to find the locally optimal solution
        // in hopes the final answer will be the globally optimal.
        // Aim for minimizing the number the most at all times
        while (currentNumber > firstNumber)
        {
            if (currentNumber / 2 > firstNumber)
            {
                // No need to subtract 2 since it is not optimal 
                // (if the number is odd, it will be made even and then the algorithm 
                // will try to divide it first)
                if (currentNumber % 2 == 0)
                {
                    currentNumber /= 2;
                }
                else
                {
                    currentNumber -= 1;
                }
            }
            else if (currentNumber - firstNumber >= 2)
            {
                currentNumber -= 2;
            }
            else
            {
                currentNumber -= 1;
            }
            
            sequence.Push(currentNumber);
        }

        return sequence.ToList();
    }
}