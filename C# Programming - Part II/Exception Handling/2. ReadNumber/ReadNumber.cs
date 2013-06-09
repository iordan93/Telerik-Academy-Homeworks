using System;
class ReadNumber
{
    static int ReadANumber(int start, int end) 
    {
        int number=0;
        if (start >= end)
        {
            throw new ArgumentException("The starting number must be smaller than the ending number.");
        }
        try
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if ((number < start) || (number > end))
            {
                // It is best to leave this exception unhandled in the current method
                throw new ArgumentOutOfRangeException("", "The number is not in the specified range.");
            }
        }
        // Parsing exceptions
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big or too small.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Please enter a number.");
        }

        return number;
    }

    static int[] ReadTenNumbers(int start, int end)
    {
        // Call the method ReadANumber ten times and write the results in an integer array
        int[] numbers = new int[10];
        for (int index = 0; index <= 9; index++)
        {
            numbers[index] = ReadANumber(start, end);
            start = numbers[index];
        }
        return numbers;
    }

    static void Main()
    {
        Console.WriteLine("This program will read ten integers in the range [1; 100] from the console.");
        int start = 1;
        int end = 100;
        int[] numbers = ReadTenNumbers(start, end);
        
        // Output
        Console.WriteLine("The entered numbers are: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
    }
}
