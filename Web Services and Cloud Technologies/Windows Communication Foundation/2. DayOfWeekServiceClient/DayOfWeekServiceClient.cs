namespace _2.DayOfWeekServiceClient
{
    using System;

    public class DayOfWeekServiceClient
    {
        public static void Main()
        {
            DayOfWeekService.DayOfWeekServiceClient client = new DayOfWeekService.DayOfWeekServiceClient();
            Console.WriteLine(client.GetDayOfWeekInBulgarian(new DateTime(2013, 1, 1)));
        }
    }
}
