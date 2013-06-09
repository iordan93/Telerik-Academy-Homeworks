using System;

class ShowSignOfNumbers
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("The product is zero.");
        }
        else
        {
            if (firstNumber > 0)
            {
                if (secondNumber > 0)
                {
                    if (thirdNumber > 0)
                    {
                        Console.WriteLine("The product is positive.");
                    }
                    else
                    {
                        Console.WriteLine("The product is negative.");
                    }
                }
                else
                {
                    if (thirdNumber > 0)
                    {
                        Console.WriteLine("The product is negative.");
                    }
                    else
                    {
                        Console.WriteLine("The product is positive.");
                    }
                }
            }
            else
            {
                if (secondNumber > 0)
                {
                    if (thirdNumber > 0)
                    {
                        Console.WriteLine("The product is negative.");
                    }
                    else
                    {
                        Console.WriteLine("The product is positive.");
                    }
                }
                else
                {
                    if (thirdNumber > 0)
                    {
                        Console.WriteLine("The product is positive.");    
                    }
                    else
                    {
                        Console.WriteLine("The product is negative.");
                    }
                }
            }
        }
    }
}
