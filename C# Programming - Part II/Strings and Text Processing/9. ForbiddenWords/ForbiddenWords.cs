using System;
class ForbiddenWords
{
    static void Main()
    {
        Console.WriteLine("This program will read a message and a list of forbidden words and will mask each forbidden word in the message with asterisks.");

        // Input
        Console.WriteLine("Enther the message:");
        string message = Console.ReadLine();
        Console.WriteLine("Enter the forbidden words, separated by commas:");
        string words = Console.ReadLine();

        // Turn the list of words into an array
        string[] wordList = words.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);

        // For each word in the list of forbidden words, replace its occurrences with asterisks.
        // The number of asterisks should be the same as the length of the word
        for (int i = 0; i < wordList.Length; i++)
        {
            message = message.Replace(wordList[i], new string('*', wordList[i].Length));
        }

        // Output
        Console.WriteLine(message);
    }
}