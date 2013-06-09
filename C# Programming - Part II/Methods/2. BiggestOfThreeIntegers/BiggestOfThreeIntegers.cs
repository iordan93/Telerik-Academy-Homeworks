using System;
class BiggestOfThreeIntegers
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        int max = int.MinValue;
        if (firstNumber >= secondNumber)
        {
            max = firstNumber;
        }
        else
        {
            max = secondNumber;
        }
        return max;
    }

    static void Main()
    {
        Console.WriteLine("This program will find the biggest of three integers using the GetMax() method.");

        // Read input
        Console.Write("Type the first integer: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Type the second integer: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Type the third integer: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        // Apply the method for three integers in two steps - get the biggest of the first and second number and compare it to the third number
        int maxNumber = GetMax(GetMax(firstNumber, secondNumber), thirdNumber);

        // Output
        Console.WriteLine("The biggest number is: {0}", maxNumber);
    }
}