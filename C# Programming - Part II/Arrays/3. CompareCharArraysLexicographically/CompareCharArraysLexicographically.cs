using System;
class CompareCharArraysLexicographically
{
    static void Main()
    {
        // Read input
        Console.WriteLine("This program will compare two strings lexicographically (letter by letter).");
        Console.WriteLine("Enter the first string: ");
        string first = Console.ReadLine();
        Console.WriteLine("Enter the second string:");
        string second = Console.ReadLine();

        //If the strings have different length, the longer one is bigger
        if (first.Length < second.Length)
        {
            Console.WriteLine("The first string is smaller than the second (earlier in the lexicograhical order).");
        }
        else if (first.Length > second.Length)
        {
            Console.WriteLine("The first string is greater than the second (later in the lexicograhical order).");
        }
        // If the strings have the same length, compare them character bu character
        else
        {
            int firstCounter = 0;
            int secondCounter = 0;
            // Count how many characters of the first are before the second and vice versa
            for (int index = 0; index < first.Length; index++)
            {
                if (first[index] > second[index])
                {
                    firstCounter++;
                }
                if (first[index] < second[index])
                {
                    secondCounter++;
                }  
            }

            // Output results
            if (firstCounter > secondCounter)
            {
                Console.WriteLine("The first string is greater than the second (later in the lexicograhical order).");
            }
            else if (firstCounter < secondCounter)
            {
                Console.WriteLine("The first string is smaller than the second (earlier in the lexicograhical order).");
            }
            else if (firstCounter == secondCounter) 
            {
                Console.WriteLine("The first string is equal to the second.");
            }
        }
    }
}
