using System;
using System.Text.RegularExpressions;
class NumberOfOccurrencesOfASubstring
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and count how many times a substring is contained within it.");

        // Input
        Console.WriteLine("Enter the string to be checked:");
        string stringToCheck = Console.ReadLine();
        Console.WriteLine("Enter the substring to look for:");
        string substring = Console.ReadLine();

        // The program must look for the substring, regardless of the case. To do this, we need to convert the string to lowercase first
        stringToCheck=stringToCheck.ToLower();

        // Regex.Matches().Count returns the number of occurrences of substring within stringToCheck
        int counter = Regex.Matches(stringToCheck, substring).Count;
        
        // Output
        Console.WriteLine("The substring \"{0}\" occurrs {1} times in the string.", substring, counter);
    }
}
