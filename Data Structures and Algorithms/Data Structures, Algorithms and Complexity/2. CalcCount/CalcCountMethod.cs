using System;
using System.Diagnostics;

public class CalcCountMethod
{
    public static void Main(string[] args)
    {
        int[,] inputMatrix = new int[,] 
            {
                { 2, 5, -1, 2, 0 },
                { 2, 1, 4, -3, 2 },
                { 1, 2, -6, 4, 3 } 
            };
        long count = CalcCount(inputMatrix);
        Console.WriteLine(count);
    }

    // Analysis:
    // Given a matrix of size n * m, the algorithm makes O(n) iterations
    // and returns the number of positive numbers on each row which starts with an even number.
    // Assuming that the probability of odd or even numbers is 0.5, 
    // the number of times the inner loop should be executed should be roughly n/2.
    // The inner loop makes O(m) operations, so the overall running time 
    // should be O(n * m / 2) = O(n * m)
    public static long CalcCount(int[,] matrix)
    {
        long count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (matrix[row, 0] % 2 == 0)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}