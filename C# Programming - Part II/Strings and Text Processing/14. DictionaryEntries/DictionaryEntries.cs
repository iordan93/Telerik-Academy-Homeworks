using System;
using System.Collections.Generic;

class DictionaryEntries
{
    static void Main()
    {
        Console.WriteLine("This program will translate words using a dictionary.");

        // Input
        string[] dictionary ={
                             ".NET - platform for applications from Microsoft",
                             "CLR - managed execution environment for .NET",
                             "namespace - hierarchical organization of classes"
                             };

        // Split the dictionary entries by the first " - " to word and explanation
        List<string> words = new List<string>();
        List<string> explanations = new List<string>();
        foreach (string explainedWord in dictionary)
        {
            int separator = explainedWord.IndexOf(" - ");
            words.Add(explainedWord.Substring(0, separator));
            explanations.Add(explainedWord.Substring(separator + 3));
        }
        Console.WriteLine("Enter the word to look for:");
        string input = Console.ReadLine();

        // If the word to look for is the same as some entry, display its explanation, else display an error message.
        bool wordFound = false;
        for (int i = 0; i < words.Count; i++)
        {
            if (input == words[i])
            {
                Console.WriteLine(explanations[i]);
                wordFound = true;
            }
        }
        if (wordFound == false)
        {
            Console.WriteLine("The word was not found in the dictionary.");
        }
    }
}