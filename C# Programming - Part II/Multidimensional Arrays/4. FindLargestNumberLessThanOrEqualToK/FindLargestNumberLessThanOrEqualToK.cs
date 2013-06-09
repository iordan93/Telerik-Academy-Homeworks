using System;
class FindLargestNumberLessThanOrEqualToK
{
    static void Main()
    {
        Console.WriteLine("This program will find the largest number, smaller than or equal to a specified integer in an integer array.");

        // Read and check input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int[] array = new int[length];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the number to look for: ");
        int key = int.Parse(Console.ReadLine());

        // Do a binary search (sorting the array first)
        Array.Sort(array);
        int result = Array.BinarySearch(array, key);

        // MSDN on Array.BinarySearch
        /// <If value is not found and value is less than one or more elements in array, a negative number which is the bitwise complement 
        /// of the index of the first element that is larger than value. If value is not found and value is greater than any of the elements in array, 
        /// a negative number which is the bitwise complement of (the index of the last element plus 1).>
        // If result < 0, since ~result == -(result + 1) and we are looking for a number smaller than K, -(result + 2) is the index we need. 

        // Output
        if (result > 0)
        {
            Console.WriteLine(array[result]);   
        }
        else
        {
            Console.WriteLine(array[-result - 2]);
        }
    }
}
