using System;
class PrintIndicesOfLetters
{
    static void Main()
    {
        Console.WriteLine("This program will find the index of a given letter in an array of letters.");

        // Read input
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        // Initalize the array with letters
        char[] letters = new char[26];
        for (int index = 0; index < letters.Length; index++)
        {
            letters[index] = (char)(index + 'A');
        }

        // Convert all letters to capital letters
        word = word.ToUpper();

        // Search for each letter using binary search
        for (int index = 0; index < word.Length; index++)
        {
            // Binary search in a sorted array of 26 elements
            int startIndex = 0;
            int finalIndex = letters.Length;
            int answer = 0;
            while (startIndex <= finalIndex)
            {
                // Check which half of the array contains the element.
                int middleIndex = (startIndex + finalIndex) / 2;
                if (letters[middleIndex] < word[index])
                {
                    startIndex = middleIndex + 1;
                }
                else if (letters[middleIndex] > word[index])
                {
                    finalIndex = middleIndex - 1;
                }
                // If letters[middleIndex] is equal to the letter we are looking for, the answer has been found
                else
                {
                    answer = middleIndex;
                    break;
                }
            }
            Console.WriteLine("Index of {0} = {1}", word[index], answer);
        }
    }
}