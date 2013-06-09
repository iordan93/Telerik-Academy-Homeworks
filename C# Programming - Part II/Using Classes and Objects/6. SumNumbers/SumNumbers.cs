using System;
class SumNumbers
{
    static void Main()
    {
        Console.WriteLine("This number will sum numbers, entered by the user.");
        Console.WriteLine("Enter the numbers to sum, separated by spaces:");

        // Read the numbers from the console and convert them into an array of strings
        string allNumbers = Console.ReadLine();
        string[] split = allNumbers.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        // Parse each element and produce an array of integers
        int[] numbers= new int[split.Length];
        for (int i = 0; i < split.Length; i++)
        {
            numbers[i] = int.Parse(split[i]);
        }

        // Sum all elements of the integer array
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        // Output
        Console.WriteLine("The sum of the numbers is {0}.", sum);
    }
}
