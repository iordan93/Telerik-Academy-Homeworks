using System;
using System.Collections.Generic;
class CalculateNFactorial
{
    // To multiply two numbers as arrays, I will use the already created method for addition.
    // Since C * x = x * x * x * ... * x (C times), we will only need to add one more method.
    // This method is slower than using BigInteger for calculating factorials, but it does the job for the current problem
    static short[] AddNumbers(short[] first, short[] second)
    {
        List<int> result = new List<int>();
        int numberToCarry = 0;
        // Check which is the bigger array
        int maxLength = Math.Max(first.Length, second.Length);
        for (int i = 0; i < maxLength; i++)
        {
            int currentDigit = (i < first.Length ? first[i] : 0) + (i < second.Length ? second[i] : 0) + numberToCarry;
            numberToCarry = currentDigit / 10;
            result.Add(currentDigit % 10);
        }
        if (numberToCarry == 1)
        {
            result.Add(1);
        }
        // A modified version of the addition problem converts the list into an array of shorts for easier use
        int[] resultArray = result.ToArray();
        short[] shortResultArray = Array.ConvertAll(resultArray, b => (short)b);
        return shortResultArray;
    }

    static short[] MultiplyNumbers(short[] first, int second)
    {
        short[] result = new short[0];
        for (int i = 0; i < second; i++)
        {
            result = AddNumbers(result, first);
        }
        return result;
    }

    // This method prints an integer, stored as array of shorts on the console
    static void PrintArrayAsNumber(short[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--) Console.Write(arr[i]); // Reversed

        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("This program will print n! for each integer in the range [1; n], where n is specified by the user.");
        short[] factorial = { 1 };
        Console.Write("Which number would you like to print n! to? ");
        int n = int.Parse(Console.ReadLine());

        // Output
        for (int i = 1; i <= n; i++)
        {
            factorial = MultiplyNumbers(factorial, i);
            PrintArrayAsNumber(factorial);
        }
    }
}