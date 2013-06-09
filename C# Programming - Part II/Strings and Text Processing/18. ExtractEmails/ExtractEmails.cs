using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and extract all emails from it.");
        Console.WriteLine("Enter the text to be searched for emails:");
        string input = Console.ReadLine();
        
        // The regular expressiom matches one ot more characters, followed by @, then by a sequence of letters, then by ., then by 2-6 letters
        MatchCollection emails = Regex.Matches(input, "\\w+@[a-zA-Z]+?\\.[a-zA-Z]{2,6}");

        for (int i = 0; i < emails.Count; i++)
        {
            Console.WriteLine(emails[i]);
        }
    }
}