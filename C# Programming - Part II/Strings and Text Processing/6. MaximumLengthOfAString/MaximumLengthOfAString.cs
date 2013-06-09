using System;
class MaximumLengthOfAString
{
    static void Main()
    {
        Console.Write("This program will read a string and produce a new string. If the original string's length is less than ");
        Console.WriteLine("20 symbols, the remaining symbols will be masked with asterisks.");
        
        // Input
        Console.WriteLine("Enter an expression:");
        string input = Console.ReadLine();

        if (input.Length > 20)
        {
            Console.WriteLine("The expression must not be longer than 20 symbols. Please try again.");
            return;
        }
        input = input.PadRight(20, '*');

        // Output
        Console.WriteLine(input);
    }
}
