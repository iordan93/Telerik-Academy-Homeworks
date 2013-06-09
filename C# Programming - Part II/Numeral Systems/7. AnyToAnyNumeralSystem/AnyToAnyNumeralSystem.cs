using System;
using System.Collections.Generic;
class AnyToAnyNumeralSystem
{
    // To convert the numbers, I use the basic rules and the previous problems, adapting them to work with more numeral systems.
    static int ConvertToDecimal(string number, int baseFrom)
    {
        // Get the number and multiply it by its corresponding power of the starting base
        int result = 0;
        for (int i = number.Length - 1, power = 1; i >= 0; i--, power *= baseFrom)
        {
            result += GetNumber(number[i]) * power;
        }
        return result;
    }

    static string ConvertFromDecimal(int number, int baseTo)
    {
        // Get the remnants in reverse order
        string result = string.Empty;
        while (number != 0)
        {
            result = GetSymbol(number % baseTo) + result;
            number /= baseTo;
        }
        return result;
    }

    static int GetNumber(char s)
    {
        // Get the current number from an array. We need this because the letters A - F act as numbers
        char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 0; i < symbols.Length; i++)
        {
            if (s == symbols[i])
            {
                return i;
            }
        }
        return -1;
    }

    static char GetSymbol(int i)
    {
        char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        return symbols[i];
    }

    static string Convert(string number, int baseFrom, int baseTo)
    {
        int temp = ConvertToDecimal(number, baseFrom);
        string result = ConvertFromDecimal(temp, baseTo);
        return result;
    }

    static void Main()
    {
        // Read the input
        Console.WriteLine("This program will convert a number from any to any other numeral system in the range [2; 16]");
        Console.Write("Please enter the numeral system to convert from: ");
        int startSystem = int.Parse(Console.ReadLine());
        Console.Write("Please enter the numeral system to convert to: ");
        int endSystem = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number in base {0}: ", startSystem);
        string number = Console.ReadLine().ToUpper();

        // Produce output
        if (startSystem < 2 || endSystem < 2 || startSystem > 16 || endSystem > 16)
        {
            Console.WriteLine("The numeral systems must be in the range [2; 16]");
        }
        else
        {
            string s = Convert(number, startSystem, endSystem);
            Console.WriteLine(s);
        }
    }
}
