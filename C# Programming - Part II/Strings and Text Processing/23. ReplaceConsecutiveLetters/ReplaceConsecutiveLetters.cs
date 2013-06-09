using System;
using System.Text.RegularExpressions;
class ReplaceConsecutiveLetters
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and replace each sequence of letters with a single letter.");

        // Input
        Console.WriteLine("Enter the expression to convert:");
        string input = Console.ReadLine();

        // Replace all groups of one or more consecutive characters with the first group found
        string replaced=Regex.Replace(input, "(\\w)\\1+", "$1");
        
        Console.WriteLine("The replaced string is: {0}", replaced);
    }
}