using System;
using System.Globalization;
using System.Threading;
class NumberOfDays
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.WriteLine("This program will read two dates and calculate the number of days between them.");

        // To convert the expressions to DateTime, it is best to use the built-in DateTime.Parse() method.
        // Another way to do this would be with regular expressions
        Console.WriteLine("Enter the first date in the format day.month.year:");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second date in the format day.month.year:");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        // If the second day is before the first, the method will return a negative value. Since negative days are not defined,
        // we take the absolute value of the period
        int period = Math.Abs((secondDate - firstDate).Days);
        Console.WriteLine("There are {0} days between the specified dates.", period);
    }
}