using System;

class SolveThreeTasks
{
    // Using the method from a previous problem
    static void ReverseDigitsOfANumber(int number)
    {
        while (number < 0)
        {
            Console.WriteLine("The number must be non-negative. Try again.");
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            ReverseDigitsOfANumber(n);
            return;
        }
        int result = 0;
        while (number > 0)
        {
            result = result * 10 + number % 10;
            number /= 10;
        }
        Console.WriteLine("Reversed number: {0}", result);
        return;
    }

    static void CalculateAverageInASequence()
    {
        Console.Write("How many elements should the integer sequence have? ");
        int n = int.Parse(Console.ReadLine());
        // Initialize an array for the sequence
        int[] sequence = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element {0}: ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        // Sum the members of the array and find the average
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += sequence[i];
        }
        double average = sum / n;
        Console.WriteLine("The average of the sequence is {0}.", average);
    }

    static void SolveLinearEquation()
    {
        Console.Write("Enter the coefficient of x: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the free member: ");
        int b = int.Parse(Console.ReadLine());

        // There are three cases - a = 0, b = 0; a = 0, b =/= 0; a=/=0, b=/= 0
        if ((a == 0) && (b == 0))
        {
            Console.WriteLine("Every number is a solution to the equation 0 * x = 0");
        }
        else if ((a == 0) && (b != 0))
        {
            Console.WriteLine("The equation 0 * x = {0} has no real roots.", b);
        }
        else
        {
            double result = -b / a;
            Console.WriteLine("The solution to {0} * x + {1} = 0 is {2}.", a, b, result);
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will solve one of three tasks, specified by the user.");
        Console.WriteLine("Which task would you like to solve?");
        Console.WriteLine("Press 1 to reverse the digits of a number");
        Console.WriteLine("Press 2 to calculate the average in an integer sequence of digits");
        Console.WriteLine("Press 3 to solve a linear equation a * x + b = 0");
        int key = int.Parse(Console.ReadLine());

        switch (key)
        {
            case 1:
                Console.Write("Enter a number: ");
                int n = int.Parse(Console.ReadLine());
                ReverseDigitsOfANumber(n);
                break;

            case 2:
                CalculateAverageInASequence();
                break;

            case 3:
                SolveLinearEquation();
                break;
            default:
                Console.WriteLine("Enter one of the numbers - 1, 2, or 3.");
                break;
        }
    }
}