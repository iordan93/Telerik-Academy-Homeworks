namespace _1.DayOfWeekService
{
    using System;
    using System.Globalization;

    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDayOfWeekInBulgarian(DateTime date)
        {
            return date.ToString("dddd", CultureInfo.CreateSpecificCulture("bg-BG"));
        }
    }
}
