using System;
using System.Globalization;
class DayOfTheWeek
{
    static void Main()
    {
        Console.WriteLine("This program will print what day of the week is today.");
        DateTime today = DateTime.Today;
        Console.WriteLine("Today is {0}.", today.DayOfWeek.ToString());
    }
}
