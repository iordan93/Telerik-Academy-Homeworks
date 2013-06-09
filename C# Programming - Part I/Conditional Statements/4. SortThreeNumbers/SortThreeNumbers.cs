using System;
class SortThreeNumbers
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());
        double biggestNumber = 0;
        double middleNumber = 0;
        double smallestNumber = 0;
        if (firstNumber > secondNumber)
        {
            if (thirdNumber > firstNumber)
            {
                biggestNumber = thirdNumber;
                middleNumber = firstNumber;
                smallestNumber = secondNumber;
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    biggestNumber = firstNumber;
                    middleNumber = secondNumber;
                    smallestNumber = thirdNumber;
                }
                else
                {
                    biggestNumber = firstNumber;
                    middleNumber = thirdNumber;
                    smallestNumber = secondNumber;
                }
            }
        }
        else
        {
            if (thirdNumber > secondNumber)
            {
                biggestNumber = thirdNumber;
                middleNumber = secondNumber;
                smallestNumber = firstNumber;
            }
            else
            {
                if (firstNumber > thirdNumber)
                {
                    biggestNumber = secondNumber;
                    middleNumber = firstNumber;
                    smallestNumber = thirdNumber;
                }
                else
                {
                    biggestNumber = secondNumber;
                    middleNumber = thirdNumber;
                    smallestNumber = firstNumber;
                }
            }
        }
        Console.WriteLine("Here are the sorted numbers: {0}; {1}; {2}", biggestNumber, middleNumber, smallestNumber);
    }
}