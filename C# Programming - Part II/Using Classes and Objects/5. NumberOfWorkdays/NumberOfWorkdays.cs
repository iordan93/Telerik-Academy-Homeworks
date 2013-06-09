using System;

class NumberOfWorkdays
{
    public static DateTime[] Holidays =
        {
            new DateTime(2013,1,1),
            new DateTime(2013,3,3),
            new DateTime(2013,5,1),
            new DateTime(2013,5,2),
            new DateTime(2013,5,3),
            new DateTime(2013,5,4),
            new DateTime(2013,5,5),
            new DateTime(2013,5,6),
            new DateTime(2013,5,24),
            new DateTime(2013,9,6),
            new DateTime(2013,9,22),
            new DateTime(2013,12,24),
            new DateTime(2013,12,25),
            new DateTime(2013,11,26),
            new DateTime(2013,12,31)
        };

    static DateTime ReadInput()
    {
        // Read the input
        Console.Write("Enter a date in the format DD/MM/YYYY or DD.MM.YYYY: ");
        string fullDate = Console.ReadLine();
        char[] separator = new char[] { '/', '.' };
        string[] splitDate = fullDate.Split(separator, 3);
        int day = int.Parse(splitDate[0]);
        int month = int.Parse(splitDate[1]);
        int year = int.Parse(splitDate[2]);
        DateTime date = new DateTime(year, month, day);
        return date;
    }

    static int WorkdaysCount(int timeElapsed, DateTime date)
    {
        int counter = 0;

        // For each day, check if it is Saturday, Sunday, or an official holiday
        // First increment the day, then chrck if it is Saturday or Sunday.
        // If not, check if it is in the list of predefined holidays.
        // If not, increment the counter
        for (int index = 0; index < timeElapsed; index++)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
            {
                bool isHoliday = false;
                for (int holiday = 0; holiday < Holidays.Length; holiday++)
                {
                    if (date == Holidays[holiday])
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if (isHoliday == false)
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    static void Main()
    {
        Console.WriteLine("This program will find the number of workdays between today and a specified date.");

        DateTime date = ReadInput();

        int timeElapsed = (date - DateTime.Today).Days;
        // If the final day is before today, the elapsed time is smaller than zero, which can be easily fixed
        if (timeElapsed < 0)
        {
            timeElapsed = -timeElapsed;
        }
        int counter = WorkdaysCount(timeElapsed, date);

        Console.WriteLine("There are {0} workdays between today and the specified date.", counter);
    }
}