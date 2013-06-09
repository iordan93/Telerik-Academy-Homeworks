using System;

class ReverseString
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and reverse it.");
        Console.WriteLine("Enter the string you want to reverse:");
        string s = Console.ReadLine();

        // Print the string as a char array in reversed order
        for (int i = s.Length - 1; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
        Console.WriteLine();
    }
}