using System;
class HexadecimalToDecimal
{
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

    static int HexToDec(string number)
    {
        // Do the usual conversion - get the number and multiply it by its corresponding power of 16.
        // This time we need more numbers which can be taken from an array
        int result = 0;
        for (int i = number.Length - 1, power = 1; i >= 0; i--, power *= 16)
        {
            result += GetNumber(number[i]) * power;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("This program will get an integer in hexadecimal numberal system and convert it to decimal numeral system.");
        Console.Write("Enter a positive hexadecimal number: ");
        string number = Console.ReadLine();

        int result = HexToDec(number);
        
        Console.WriteLine("{0} in decimal numeral system is {1}.", number, result);
    }
}