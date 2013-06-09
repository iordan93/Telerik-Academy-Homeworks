using System;
using System.Collections.Generic;

class SortStringArrayByLength
{
    static void Main()
    {
        Console.WriteLine("This program will find the largest number, smaller than or equal to a specified integer in an integer array.");

        // Read and check input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        string[] array = new string[length];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = Console.ReadLine();
        }

        // Using custom sorting - compare two strings by length
        Array.Sort(array, new StringLengthComparer());
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public class StringLengthComparer : IComparer<string>
    {
        public int Compare(string firstString, string secondString)
        {
            return firstString.Length.CompareTo(secondString.Length);
        }
    }
}