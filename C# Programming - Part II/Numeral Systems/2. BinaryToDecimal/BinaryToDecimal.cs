using System;
class BinaryToDecimal
{
    static int BinToDec(string number)
    {
        // Do the usual conversion - get the number and multiply it by its corresponding power of 2
        int result = 0;
        for (int i = number.Length - 1, power = 1; i >= 0; i--, power *= 2)
        {
            result += (number[i] - '0') * power;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("This program will get an integer in binary numberal system and convert it to decimal numeral system.");
        Console.Write("Enter a positive binary number: ");
        string number = Console.ReadLine();

        int result = BinToDec(number);

        Console.WriteLine("{0} in decimal numeral system is {1}.", number, result);
    }

}
