using System;
using System.Text.RegularExpressions;
class GetSentences
{
    static void Main()
    {
        Console.WriteLine("This program will read a string message and extract from it all messages which contain a specified word.");

        // Input
        Console.WriteLine("Enther the message:");
        string message = Console.ReadLine();
        Console.Write("Enter the word to search for: ");
        string word = Console.ReadLine();

        // Considering each sentence ends with a dot, separate the sentences and produce a string array
        string[] sentences = message.Split(new string[] { ".", ". " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string sentence in sentences)
        {
            // For each sentence, write it if it contains the word (\b means beginning/end of a word) at least once
            if (Regex.Matches(sentence, @"\b" + word + @"\b", RegexOptions.IgnoreCase).Count > 0)
            {
                Console.WriteLine(sentence + ".");
            }
        }
    }
}