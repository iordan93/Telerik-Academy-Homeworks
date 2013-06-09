using System;
class PrintCombinations
{
    static void Main()
    {
        Console.WriteLine("This program will find all combinations of K numbers in the range [1; ...; N].");
        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int k = 0;
        while ((k <= 0) || (k > length))
        {
            Console.Write("How many elements should each combination contain? ");
            k = int.Parse(Console.ReadLine());
        }

        // Find the combinations recursively and produce output
        int[] array = new int[k];
        FindCombinations(array, 0, 1, length);
    }
    static void FindCombinations(int[] array, int start, int current, int length)
    {
        // If the starting element is equal to the length of the array, print the array.
        if (start == array.Length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
            // If the starting element is not equal to the length of the array, call a recursive function for (n-1) elements.
            // Do this while start = array.Length, when the program goes into the first case and finish the recursion.
        else
        {
            for (int i = current; i <= length; i++)
            {
                array[start] = i;
                FindCombinations(array, start + 1, i + 1, length);
            }
        }
    }
}
