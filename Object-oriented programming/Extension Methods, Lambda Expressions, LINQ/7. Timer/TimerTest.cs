using System;
using System.Threading;

namespace _7.Timer
{
    class TimerTest
    {
        // The method to be executed using the delegate
        public static void MethodToExecute()
        {
            Console.WriteLine(DateTime.Now);
        }

        static void Main()
        {
            // Input
            Console.Write("Please specify the number of seconds the timer will show the time: ");
            
            // Make a new instance of the Timer class which 'ticks' every second
            Timer timer = new Timer();
            // The multipication by 1000 returns the result in seconds
            timer.Timespan = int.Parse(Console.ReadLine()) * 1000;

            // Attach the testing method to the delegate
            timer.TimerMethod = MethodToExecute;
            // Start the timer - execute the method each second
            timer.TimerTick();
        }
    }
}
