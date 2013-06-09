using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class ReverseWordsInASentence
{
    static void Main()
    {
        Console.WriteLine("This program will reverse all words in a sentence, but will keep the punctuation marks.");

        // Input
        Console.WriteLine("Enter the sentence to reverse:");
        string input = Console.ReadLine();

        List<string> words = new List<string>();
        List<string> punctuation = new List<string>();

        // Split all words by the punctuation signs and add them to a list
        // The regular expression catches everything after a whitespace (greedy):
        // (space + everything until \r\n) or (, + space + word) or (! + space + word) or (? + space + word)
        string[] splitWords = Regex.Split(input, @"\s+|,\s*|\.\s*|!\s*|\?\s*");
        foreach (string word in splitWords)
        {
            words.Add(word);
        }

        // Using the same regular expression, extract each match and add the matches to another list.
        // Punctuation includes whitespaces too
        MatchCollection punctuationSigns = Regex.Matches(input, @"\s+|,\s*|\.\s*|!\s*|\?\s*");
        foreach (Match punctuationSign in punctuationSigns)
        {
            punctuation.Add(punctuationSign.ToString());
        }

        // Output - write the words in reversed order 
        // and add the punctuation (including spaces) in the same place it was at the beginning
        // (Count - i - 1) to write the sentence in reverse order - 1 more index, because the last element is ""
        for (int i = 0; i < punctuation.Count; i++)
        {
            Console.Write(words[words.Count - i - 2] + punctuation[i]);
        }
        Console.WriteLine();
        
    }
}