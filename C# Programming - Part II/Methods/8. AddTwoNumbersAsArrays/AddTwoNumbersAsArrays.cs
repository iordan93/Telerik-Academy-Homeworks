using System;
using System.Collections.Generic;
class Program
{
    // To represent the digits as arrays, make the string a char[] array, then reverse it (the lowest number should be at position 0).
    // Then get the number using its index.
    static short[] RepresentIntegerAsArray(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        short[] shortArray = new short[charArray.Length];
        for (int index = 0; index < charArray.Length; index++)
        {
            shortArray[index] = (short)(charArray[index] - '0');
        }
        return shortArray;
    }

    // The digits should be added as if on paper - starting from the lowest one, sum the corresponding elements of the array.
    // If there is an "overflow", e. g. "19", store the 9 and carry the 1 to the next element
    static List<int> AddNumbers(short[] first, short[] second)
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
        return result;
    }

    static void Main()
    {
        Console.WriteLine("This program will add two positive integers, represented as arrays.");

        // Read input
        Console.Write("Enter the first integer: ");
        string first = Console.ReadLine();
        Console.Write("Enter the second integer: ");
        string second = Console.ReadLine();

        // Represent the integers as arrays
        short[] firstNumber = RepresentIntegerAsArray(first);
        short[] secondNumber = RepresentIntegerAsArray(second);

        // Sum the numbers
        List<int> result = AddNumbers(firstNumber, secondNumber);

        // Output (it should be "reversed" to start with the greatest power of 10)
        for (int i = result.Count - 1; i >= 0; i--)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine();
    }
}