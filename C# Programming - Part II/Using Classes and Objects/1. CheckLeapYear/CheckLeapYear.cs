using System;
class CheckLeapYear
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program will check whether a given year is leap or not, using DateTime.");
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());

        // Using the built-in function, check if the year is leap.
        // To spice the problem a bit, I added a little exception handling.
        // A better solution that works even with negative numbers is to check divisibility by 4
        // year % 4 = 0 => leap; year % 100 = 0 => not leap; year % 400 = 0 => leap
        bool leapYear = false;
        try
        {
            leapYear = DateTime.IsLeapYear(year);
        }
        catch (ArgumentOutOfRangeException) 
        {
            Console.WriteLine("The year must be a number between 1 and 9999. Try again.");
            return;
        }

        if (leapYear)
        {
            Console.WriteLine("The year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", year);
        }
        
    }
}