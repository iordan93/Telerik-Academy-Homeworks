using System;
class ReturnLastDigitAsWord
{
    static string ReturnEnglishName(string number)
    {
        // Convert the last digit to its corresponding English word.
        // If the input is actually not a digit, show a message to correct it.
        short lastDigit = GetLastDigit(number);
        switch (lastDigit)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default:
                return "Your input is wrong. Try again.";
        }
    }

    static short GetLastDigit(string number)
    {
        // Get the last symbol of the string - it is much faster than parsing the entire string
        string lastSymbol = number.Substring(number.Length - 1);

        // Try to parse the last digit as short
        short lastDigit = 0;
        try
        {
            lastDigit = short.Parse(lastSymbol);
        }

            // If the input is not correct, return -1
        catch (FormatException)
        {
            return -1;
        }
            return lastDigit;
    }

    static void Main()
    {
        Console.WriteLine("This program will return the last digit of a number.");

        // Read the input
        Console.Write("Enter the number: ");
        string number = Console.ReadLine();

        string lastDigitName = ReturnEnglishName(number);

        // Output
        Console.WriteLine("The last digit is {0}.", lastDigitName);
    }
}