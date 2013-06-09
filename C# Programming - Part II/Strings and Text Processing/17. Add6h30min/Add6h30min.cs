using System;
using System.Globalization;
using System.Threading;

class Add6h30min
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.WriteLine("This program will read a date and add 6 hours and 30 minutes to it.");

        // Input
        Console.WriteLine("Enter a date in the format day.month.year hours:minutes:seconds:");
        
        // Parse the date and add 6 ana a half hours. To get the day of week, use the formatting string "dddd" along with bg-BG culture
        DateTime inputDate = DateTime.Parse(Console.ReadLine());
        DateTime result = inputDate.AddHours(6.5);
        string dayOfWeek = result.ToString("dddd", new CultureInfo("bg-BG"));

        Console.WriteLine("The final date is {0} - {1}", result, dayOfWeek);
    }
}
