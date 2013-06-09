using System;

class SieveOfErathostenes
{
    static void Main()
    {
        Console.WriteLine("This program will find the prime numbers in the range [1; 10 000 000] using the \"sieve of Erathostenes\" algorithm.");
        // A tricky solution proposes making a boolean array, setting its values and printing its indices instead of working with integers.
        // The original algorithm supposes the elements are set to "true". I want to save some processor time, so I won't set them.
        // If an element is true, then it's not prime and the program will print all elements which are false 
        bool[] array = new bool[10000000];
        
        for (int i = 2; i < Math.Sqrt(array.Length); i++)
        {
            if (array[i] == false)
            {
                // Remove all multiplies of i except i
                for (int j = 2*i; j < array.Length; j+=i)
                {
                    array[j] = true;
                }
            }
        }
        // Output results
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == false)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}