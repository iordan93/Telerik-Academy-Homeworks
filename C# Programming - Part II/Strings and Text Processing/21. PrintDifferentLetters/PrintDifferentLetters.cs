using System;
class PrintDifferentLetters
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and provide information how many times each different letter is contained in it.");

        // Input
        Console.WriteLine("Enter the string to be checked:");
        string input = Console.ReadLine();

        // We will keep only the letters A-Z and a-z, so the array will be long as much as the difference between their indices + 1 (the index of z)
        int[] letters = new int['z'-'A' + 1];
        for (int i = 0; i < input.Length; i++)
        {
            // If the current character is a letter, increment its corresponding value in the array of characters
            if ((input[i] >= 'A') && (input[i] <= 'z'))
            {
                letters[input[i] - 'A']++;
            }
        }
        for (int i = 0; i < letters.Length; i++)
        {
            // Write each letter which occurs at least once in the string. To get the letter, increment the index again with the index of 'A'
            if (letters[i] != 0)
            {
                Console.WriteLine("{0} - {1}", (char)(i + 'A'), letters[i]);
            }
        }
    }
}