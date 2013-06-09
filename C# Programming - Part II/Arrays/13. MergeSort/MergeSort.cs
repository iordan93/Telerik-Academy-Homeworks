using System;
class MergeSort
{
    static void Main()
    {
        Console.WriteLine("This program will sort an integer array using the merge sort algorithm.");

        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int[] unsortedArray = new int[length];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            unsortedArray[index] = int.Parse(Console.ReadLine());
        }

        // Solve problem
        int[] sortedArray = DoMergeSort(unsortedArray);

        // Produce ooutput
        Console.WriteLine("Sorted array: ");
        for (int p = 0; p < length; p++)
        {
            Console.Write("{0} ", sortedArray[p]);
        }
    }

    private static int[] DoMergeSort(int[] array)
    {
        if (array.Length > 1)
        {
            // Split the array in half and make two new arrays
            int elementsFirst = array.Length / 2;
            int elementsSecond = array.Length - elementsFirst;
            int[] firstArray = new int[elementsFirst];
            int[] secondArray = new int[elementsSecond];

            // Populate the arrays
            for (int i2 = 0; i2 < elementsFirst; i2++)
            {
                firstArray[i2] = array[i2];
            }
            for (int i3 = elementsFirst; i3 < elementsFirst + elementsSecond; i3++)
            {
                secondArray[i3 - elementsFirst] = array[i3];
            }
            
            // Recursively call the function for the two newly created arrays to split them
            firstArray = DoMergeSort(firstArray);
            secondArray = DoMergeSort(secondArray);

            int index = 0;
            int indexFirst = 0;
            int indexSecond = 0;

            // While the arrays still have elements to look for, compare them and prepare the final array
            while ((firstArray.Length != indexFirst) && (secondArray.Length != indexSecond))
            {
                if (firstArray[indexFirst] < secondArray[indexSecond])
                {
                    // Copy the current element from the first array in the final array and increase the indices to proceed with sorting
                    array[index] = firstArray[indexFirst];
                    index++;
                    indexFirst++;
                }

                else
                {
                    // Copy the current element from the second array in the final array and increase the indices to proceed with sorting
                    array[index] = secondArray[indexSecond];
                    index++;
                    indexSecond++;
                }
            }
            // If the length of one array is equal to the index, the arrays have no more elements to look for - everything is sorted.
            // If not, proceed with sorting, in a similar way as above
            while (firstArray.Length != indexFirst)
            {
                array[index] = firstArray[indexFirst];
                index++;
                indexFirst++;
            }
            while (secondArray.Length != indexSecond)
            {
                array[index] = secondArray[indexSecond];
                index++;
                indexSecond++;
            }
        }
        // Return the sorted array
        return array;
    }
}