using System;
using System.Text.RegularExpressions;
class ExtractAllPalindromes
{
    static void Main()
    {
        Console.Write("This program will read a string and extract all palindromes from it. Palindromes are words which can be read both left to right ");
        Console.WriteLine("and right to left and mean the same thing.");

        // Input
        Console.WriteLine("Enter the string to be checked for palindromes:");
        string input = Console.ReadLine();

        string[] wordsWithPunctuation = input.Split(new string[] { " ", }, StringSplitOptions.RemoveEmptyEntries);
        string[] words = new string[wordsWithPunctuation.Length];
        for (int i = 0; i < wordsWithPunctuation.Length; i++)
        {
            // Remove all punctuation which might be left in the string
            words[i] = Regex.Replace(wordsWithPunctuation[i], "\\p{P}", "");
        }

        foreach (string word in words)
        {
            // For each word, check if its first half is equal to its second half
            bool isPalindrome = true;
            for (int index = 0; index < word.Length / 2; index++)
            {
                if (word[index] != word[word.Length-index-1])
                {
                    isPalindrome = false;
                }
                else
                {
                    isPalindrome = true;
                }
            }

            // If the two halves of the word are equal, write it
            if (isPalindrome)
            {
                Console.WriteLine(word);
            }
        }
    }
}