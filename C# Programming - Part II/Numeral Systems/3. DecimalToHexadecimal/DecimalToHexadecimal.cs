using System;
class DecimalToHexadecimal
{
    static char GetSymbol(int i)
    {
        // We need to define a little more "numbers" - the letters A - F now play the part of numbers.
        char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        return symbols[i];
    }

    static string DecToHex(int number)
    {
        string result = string.Empty;
        while (number != 0)
        {
            result = GetSymbol(number % 16) + result;
            number /= 16;
        }
        return result;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("This program will get an integer in decimal numberal system and convert it to hexadecimal numeral system.");
        Console.Write("Enter a positive decimal number: ");
        int number = int.Parse(Console.ReadLine());

        string result = DecToHex(number);
        
        Console.WriteLine("{0} in hexadecimal numeral system is 0x{1}.",number,result);
    }
}