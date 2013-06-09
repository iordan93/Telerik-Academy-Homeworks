using System;
class QuickSort
{
    static void Main()
    {
        Console.WriteLine("This program will sort an array of strings using the quicksort algorithm.");

        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        string[] array = new string[length];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = Console.ReadLine();
        }


        // Quicksort
        DoQuickSort(array, 0, array.Length - 1);

        // Output
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

    }
    // Swap two elements in the array
    static void Swap(string[] array, int left, int right)
    {
        string temp = array[right];
        array[right] = array[left];
        array[left] = temp;
    }

    static void DoQuickSort(string[] array, int left, int right)
    {
        // Initialize the two markers for quicksort. "leftPosition" and "rightPosition" will hold the values after "left" and "right" change
        int leftPosition = left;
        int rightPosition = right;

        // Randomly generate a pivot between the left and right markers and set the left marker to it
        Random randomNumber = new Random();
        int pivot = randomNumber.Next(left, right);
        Swap(array, pivot, left);
        pivot = left;
        left++;

        while (right >= left)
        {
            // Compare the left and right markers with the pivot element 
            // Array.CompareTo() returns 0 if the strings are equal, integer < 0 if the first string is earlier and integer > 0 if the second string is earlier
            int compareLeft = array[left].CompareTo(array[pivot]);
            int compareRight = array[right].CompareTo(array[pivot]);
            // If the left element is after the right element lexicographically, swap them
            if ((compareLeft >= 0) && (compareRight < 0))
            {
                Swap(array, left, right);
            }
            else
            {
                // Decrease the right markers and increase the left markers

                if (compareLeft >= 0)
                {
                    right--;
                }
                else
                {
                    if (compareRight < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                        left++;
                    }
                }
            }
        }

        // Swap the pivot with the right marker
        Swap(array, pivot, right);
        pivot = right;

        // Recursively call the quicksort function for the two subarrays
        if (pivot > leftPosition)
        {
            DoQuickSort(array, leftPosition, pivot);
        }
        if (rightPosition > pivot + 1)
        {
            DoQuickSort(array, pivot + 1, rightPosition);
        }
    }
}