using System;
using System.Diagnostics;

public class ComputeMethod
{
    public static void Main(string[] args)
    {
        // The difference between the two algorithms is noticeable - about 3.6 times on my computer
        int[] inputArray = new int[] { 1, 2, 5, 4 };
        Stopwatch timer = new Stopwatch();
        
        timer.Start();
        for (int i = 0; i < 10000000; i++)
        {
            Compute(inputArray);
        }

        timer.Stop();
        Console.WriteLine("Original method time: {0}", timer.Elapsed);
        
        timer.Restart();
        for (int i = 0; i < 10000000; i++)
        {
            ComputeFixed(inputArray);
        }

        timer.Stop();
        Console.WriteLine("Fixed method time: {0}", timer.Elapsed);
    }

    // Analysis:
    // Given an array of size n, the algorithm loops through each element - O(n) steps.
    // First, the start and end variables are assigned to the start and end of the array, so end - start = n.
    // The difference between end and start decreases by one on each iteration. The while loop terminates when end - start = 0.
    // As this takes O(n) operations, the complexity of the algorithm is O(n*n) = O(n^2).
    public static long Compute(int[] arr)
    {
        long count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                if (arr[start] < arr[end])
                {
                    start++;
                    count++;
                }
                else
                {
                    end--;
                }
            }
        }

        return count;
    }

    // A quick fix can make the algorithm run much faster - in O(n) time.
    // As we perform the same operations n times, the outer loop is practically useless, 
    // and the while-loop can be refactored into a reverse for-loop:
    public static long ComputeFixed(int[] array)
    {
        int result = 0;

        for (int i = array.Length - 1; i > 0; i--)
        {
            if (array[result] < array[i])
            {
                result = i;
            }
        }

        // The multiplication replaces the useless outer loop
        result *= array.Length;
        return result;
    }
}