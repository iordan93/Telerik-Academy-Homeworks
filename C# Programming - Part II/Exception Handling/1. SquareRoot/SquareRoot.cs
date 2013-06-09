using System;
class SquareRoot
{
    static void Main()
    {
        Console.WriteLine("This program will calculate the square root of a number, input by the user.");
        Console.Write("Enter a number: ");
        try
        {
            double number = double.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArithmeticException("Square root is defined for nonnegative numbers only");
            }
            double root = Math.Sqrt(number);
            Console.WriteLine(root);
        }

        // Parsing can lead to one of the three exceptions - FormatException, OverflowException, or ArgumentNullException
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number. Try again.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big or too small. Try again.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Please enter a number. Try again.");
        }

        // Getting the square root of a negative number leads to getting an arithmetic exception, as defined above
        catch (ArithmeticException)
        {
            Console.WriteLine("Square root is defined for nonnegative numbers only. Try again.");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}