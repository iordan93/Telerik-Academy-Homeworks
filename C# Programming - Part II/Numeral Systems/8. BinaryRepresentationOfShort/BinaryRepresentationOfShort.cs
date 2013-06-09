using System;
class BinaryRepresentationOfShort
{
    // To take the short representation, I will use the decimal to binary conversion algorithm, adapted to 16-bit numbers
    static string ShortRepresentation(short number)
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
            result = ShortRepresentation((short)(number + short.MinValue));
            result = "1" + result.Substring(1);
        }
        // If needed, add leading zeros to represent the number as Int16 type
        return result.PadLeft(16, '0');
    }
    
    static void Main()
    {
        Console.WriteLine("This program will print the binary representation of a given 16-bit (short) number.");
        Console.Write("Enter a decimal number: ");
        short number = short.Parse(Console.ReadLine());
        string representation = ShortRepresentation(number);
        Console.WriteLine("The binary representation of {0} is {1}.", number, representation);
    }
}