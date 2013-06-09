using System;
class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("This program will calculate the greatest common divisor of two numbers.");
        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        int temp;
        //Euclidean algorithm
        while (secondNumber != 0)
        {
            temp = secondNumber;
            secondNumber = firstNumber % secondNumber;
            firstNumber = temp;
        }
        Console.WriteLine(firstNumber);
    }
}