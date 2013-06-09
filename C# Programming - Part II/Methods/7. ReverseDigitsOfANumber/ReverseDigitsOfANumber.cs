using System;
class ReverseDigitsOfANumber
{
    static int ReverseDigits(int number) 
    {
        int result = 0;
        // Similar to bitwise operations, "shift" the result left and add the last digit of the number.
        // Then divide the number by 10 to get the next digit and so on
        while (number > 0) 
        {
            result = result * 10 + number % 10;
            number /= 10;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("This program will read an integer and will reverse its digits.");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int reversed = ReverseDigits(number);
        Console.WriteLine("The reversed number is: {0}", reversed);
    }
}
