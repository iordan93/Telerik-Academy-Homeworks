using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PrintDifferentWords
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and provide information how many times each different word is contained in it.");

        // Input
        Console.WriteLine("Enter the string to be checked:");
        string input = Console.ReadLine();

        // It is best to use the Dictionary<string, int> data structure. It is basically an array of integers whose indices are strings.
        // The indices will be the words, and the values will be the counters of each word
        Dictionary<string,int> dictionary = new Dictionary<string, int>();

        // Check each match which is a word
        MatchCollection matches = Regex.Matches(input, "\\w+");

        // If the word is already in the dictionary, increment the value (e.g. counter) by one.
        // If not, create a new dictionary entry
        for (int i = 0; i < matches.Count; i++)
        {
            if (dictionary.ContainsKey(matches[i].Value))
            {
                dictionary[matches[i].Value]++;
            }
            else
            {
                dictionary[matches[i].Value] = 1;
            }
        }

        // For each word (stored as KeyValuePair<string, int>), write its occurrences
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        }
    }
}