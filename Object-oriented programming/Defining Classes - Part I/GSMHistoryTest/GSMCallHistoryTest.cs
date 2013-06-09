using System;
using System.Linq;
using GSMData;

namespace GSMTest
{
    class GSMTest
    {
        static void Main()
        {
            GSM gsm = GSM.IPhone4S;

            // Add some calls
            gsm.AddCall(new Call(new DateTime(2013, 01, 15, 20, 18, 30), "0887451038", new TimeSpan(0, 10, 15)));
            gsm.AddCall(new Call(new DateTime(2013, 02, 24, 20, 18, 30), "0887451038", new TimeSpan(0, 2, 5)));
            gsm.AddCall(new Call(new DateTime(2013, 01, 9, 20, 1, 30), "0887151169", new TimeSpan(0, 5, 18)));
            gsm.AddCall(new Call(new DateTime(2013, 03, 01, 20, 18, 30), "0875327896", new TimeSpan(1, 1, 53)));
            gsm.AddCall(new Call(new DateTime(2013, 01, 10, 11, 12, 39), "0887421359", new TimeSpan(0, 40, 11)));
            gsm.AddCall(new Call(new DateTime(2013, 01, 15, 21, 15, 28), "08874112596", new TimeSpan(0, 3, 15)));

            // Print calls
            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }

            //// Remove call
            //gsm.RemoveCall(new Call(new DateTime(2013, 01, 15, 20, 18, 30), "0887451038", new TimeSpan(0, 10, 15)));
            //Console.WriteLine("---");
            //foreach (Call call in gsm.CallHistory)
            //{
            //    Console.WriteLine(call);
            //}
            decimal price = gsm.CalculatePrice();
            Console.WriteLine("{0} lv.", price);
            Console.WriteLine();
            
            // Remove longest call
            TimeSpan? maxDuration = TimeSpan.MinValue;
            DateTime maxDurationDateAndTime = DateTime.MinValue;
            string maxDurationNumber = string.Empty;
            foreach (Call call in gsm.CallHistory)
            {
                if (call.Duration > maxDuration) 
                {
                    maxDuration = call.Duration;
                    maxDurationNumber = call.DialedNumber;
                    maxDurationDateAndTime = call.DateAndTime;
                }
            }
            gsm.RemoveCall(new Call(maxDurationDateAndTime,maxDurationNumber,maxDuration));
            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }
            
            // Calculate price
            price = gsm.CalculatePrice();
            Console.WriteLine("{0} lv.", price);

            // Clear history
            Console.WriteLine("---");
            gsm.ClearCallHistory();
            Console.WriteLine("Number of calls: {0}", gsm.CallHistory.Count);
        }
    }
}
