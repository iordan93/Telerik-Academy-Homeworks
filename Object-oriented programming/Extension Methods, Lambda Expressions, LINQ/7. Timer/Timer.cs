using System;
using System.Threading;

namespace _7.Timer
{
    // Initialize a new delegate which takes no parameters and returns void
    public delegate void TimerDelegate();

    class Timer
    {
        // Private fields - instantiate the timer method and timespan
        private TimerDelegate timerMethod;
        private int timespan;

        // Public properties to encapsulate the fields
        public int Timespan
        {
            get
            {
                return this.timespan; 
            }
            set 
            {
                if (value >= 0)
                {
                    this.timespan = value;
                }
                else throw new ArgumentOutOfRangeException("TimeSpan", "The timespan must be nonnegative");
            }
        }

        public TimerDelegate TimerMethod
        {
            get
            {
                return this.timerMethod;
            }
            set
            {
                this.timerMethod = value;
            }
        }

        // Constructors - to instantiate the Timer class
        public Timer(int milliseconds) 
        {
            this.Timespan = milliseconds;
        }

        public Timer() : this(0) 
        {
        }

        // Method to hold one 'tick' - an execution of the delegate, followed by sleeping of the thread for the time specified
        public void TimerTick() 
        {
            while (true)
            {
                this.TimerMethod();
                Thread.Sleep(this.Timespan);
            }
        }
    }
}
