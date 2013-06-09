using System;
class BinarySearch
{
    static void Main()
    {
        Console.WriteLine("This program will find the index of a given number in a sorted integer array.");

        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int[] array = new int[length];
        Console.WriteLine("Enter the elements of the array one by one. The array needs to be sorted.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Which number do you want to search for?");
        int key = int.Parse(Console.ReadLine());

        // Solve the problem
        // Set the start and final index to the array's boundaries and set a flag if the answer has been found
        int startIndex = 0;
        int finalIndex = length;
        int answer = 0;
        bool answerFound = false;
        while (startIndex <= finalIndex)
        {
            // Check which half of the array contains the element.
            int middleIndex = (startIndex + finalIndex) / 2; 
            if (array[middleIndex] < key)
            {
                startIndex = middleIndex + 1;
            }
            else if (array[middleIndex] > key)
            {
                finalIndex = middleIndex - 1;
            }
                // If array[middleIndex] is equal to the key, the answer has been found
            else
            {
                answer = middleIndex;
                answerFound = true;
                break;
            }
        }

        // Output
        if (answerFound == false)
        {
            Console.WriteLine("There is no such element in the array.");
        }
        else
        {
            Console.WriteLine("Index of {0}: {1}", key, answer);
        }

    }
}
