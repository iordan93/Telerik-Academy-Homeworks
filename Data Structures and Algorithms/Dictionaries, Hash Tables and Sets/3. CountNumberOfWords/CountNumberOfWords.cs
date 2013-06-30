using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class CountNumberOfWords
{
    public static void Main()
    {
        StreamReader file = new StreamReader("../../words.txt");
        string fileContents = file.ReadToEnd();
        string[] words = Regex.Split(fileContents, "\\W+");
        
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                string wordLowercase = word.ToLowerInvariant();
                if (wordsCount.ContainsKey(wordLowercase))
                {
                    wordsCount[wordLowercase]++;
                }
                else
                {
                    wordsCount[wordLowercase] = 1;
                }
            }
        }

        Dictionary<string, int> sortedWordsCount =
            (from entry in wordsCount
             orderby entry.Value ascending
             select entry)
             .ToDictionary(pair => pair.Key, pair => pair.Value);
        
        foreach (var word in sortedWordsCount)
        {
            int occurences = wordsCount[word.Key];
            Console.WriteLine(occurences == 1 ? "{0} -> {1} time" : "{0} -> {1} times", word.Key, occurences);
        }
    }
}