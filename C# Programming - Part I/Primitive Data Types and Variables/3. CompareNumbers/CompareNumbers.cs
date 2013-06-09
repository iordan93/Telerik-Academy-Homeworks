using System;

    class CompareNumbers
    {
        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            double secondNumber = double.Parse(Console.ReadLine());
            float first = (float)firstNumber;
            float second = (float)secondNumber;
            //Console.WriteLine(first + " " + second);
            if (first > second)
            {
                Console.WriteLine("With acccuracy of 0,000001: {0} > {1}", firstNumber, secondNumber);
            }
            else if (first < second)
            {
                Console.WriteLine("With acccuracy of 0,000001: {0} < {1}", firstNumber, secondNumber);
            }
            else 
            {
                Console.WriteLine("With acccuracy of 0,000001: {0} = {1}", firstNumber, secondNumber);
            }

        }
    }
