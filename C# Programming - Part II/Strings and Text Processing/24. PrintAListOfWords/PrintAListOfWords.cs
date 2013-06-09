using System;
using System.Text.RegularExpressions;
class PrintAListOfWords
{
    static void Main()
    {
        Console.WriteLine("This program will read a list of words and sort them in alphabetical order.");

        // Input
        Console.WriteLine("Enter the words, separated by spaces:");
        string input = Console.ReadLine();

        // Split the input into words
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            // Remove all punctuation which might be left
            words[i] = Regex.Replace(words[i], "\\p{P}", "");
        }

        // Array.Sort() sorts the words in alphabetical order
        Array.Sort(words);

        // Output
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
