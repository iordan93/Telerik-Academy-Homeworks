using System;
class DecimalToBinary
{
    static string DecToBin(int number)
    {
        string result = string.Empty;

        // If the number is greater than zero, divide by two and take the remnants in reverse order
        if (number >= 0)
        {
            while (number > 0)
            {
                result = number % 2 + result;
                number /= 2;
            }
        }
        // Else, the first bit is one, take the complement of the number and do the normal conversion.
        // Then take into account the first bit and ignore the leading zero
        else
        {
            result = DecToBin(number + int.MinValue);
            result = "1" + result.Substring(1);
        }
        // If needed, add leading zeros to represent the number as Int32 type
        return result.PadLeft(32, '0');
    }

    static void Main()
    {
        Console.WriteLine("This program will get an integer in decimal numberal system and convert it to binary numeral system.");
        Console.Write("Enter a decimal number: ");
        int number = int.Parse(Console.ReadLine());
        string result = DecToBin(number);
        Console.WriteLine("{0} in binary numeral system is {1}.", number, result);
    }
}
