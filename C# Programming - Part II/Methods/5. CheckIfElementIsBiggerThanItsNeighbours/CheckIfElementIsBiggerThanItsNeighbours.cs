using System;
class CheckIfElementIsBiggerThanItsNeighbours
{
    static int[] InitializeIntArray()
    {
        Console.Write("How many numbers should the array have? ");
        int length = int.Parse(Console.ReadLine());
        int[] intArray = new int[length];
        Console.WriteLine("Now enter the elements of the array one by one.");
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0}: ", i + 1);
            intArray[i] = int.Parse(Console.ReadLine());
        }
        return intArray;
    }

    static int FirstPositionOfNumber(int[] array, int number)
    {
        // Check if the specified number exists within the array. If it exists, save the position, else return -1
        int position = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                position = i;
                break;
            }
        }
        if (position == -1)
        {
            throw new ArgumentException("The number has not been found in the array.");
        }
        else
        {
            return position;
        }
    }

    static int PositionWithinArray(int[] array, int position) 
    {
        // Check the position of the number in the array
        // Returns -1 if it is at the first position, 0 if it is at the middle, or 1 if it is at the final position
        if (position == 0)
        {
            return -1;
        }
        else if(position == array.Length-1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    static bool IsBiggerThanItsNeighbours(int[] array, int number)
    {
        // If the number exists in the array, check it, else give an error message
        int index = FirstPositionOfNumber(array, number);
        // Only one element in the array - suppose there are no neighbours and nothing to check against
        if ((array.Length == 1) && (array[0] == number))
        {
            return false;
        }
        int position = PositionWithinArray(array, index);
        // Only right neighbour exists
        if (position == -1)
        {
            if (array[index]>array[index+1])
            {
                return true;   
            }
            else
            {
                return false;
            }
        }
            // Only left neighbour exists
        else if (position == 1)
        {
            if (array[index]>array[index-1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            // Both neighbours exist
        else
        {
            if ((array[index]>array[index-1]) && (array[index]>array[index+1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will check if the element at a specified position in an integer array is bigger than its neighbours.");
        // Read input
        int[] intArray = InitializeIntArray();
        Console.Write("Which number do you want to search for? ");
        int number = int.Parse(Console.ReadLine());

        // Solve problem and produce output
        try
        {
            bool isBigger=IsBiggerThanItsNeighbours(intArray, number);
            if (isBigger)
            {
                Console.WriteLine("The number {0} is bigger than its neighbours.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is not bigger than its neighbours.", number);
            }
        }
        catch (ArgumentException) 
        {
            Console.WriteLine("The number has not been found in the array.");
        }
    }
}