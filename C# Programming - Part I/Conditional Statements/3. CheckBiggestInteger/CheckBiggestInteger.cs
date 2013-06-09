using System;
class CheckBiggestInteger
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());
        int biggestNumber = 0;
        if (firstNumber > secondNumber)
        {
            if (thirdNumber > firstNumber)
            {
                biggestNumber = thirdNumber;
            }
            else
            {
                biggestNumber = firstNumber;
            }
        }
        else
        {
            if (thirdNumber > secondNumber)
            {
                biggestNumber = thirdNumber;
            }
            else
            {
                biggestNumber = secondNumber;
            }
        }
        Console.WriteLine("The biggest number is {0}.", biggestNumber);
    }
}