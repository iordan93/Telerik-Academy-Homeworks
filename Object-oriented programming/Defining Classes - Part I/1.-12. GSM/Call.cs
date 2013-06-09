using System;
using System.Text;

namespace GSMData
{
    public class Call : IEquatable<Call>
    // IEquatable interface provides the method Equals so we can compare two calls
    // (used when deleting from CallHistory)
    {
        // Fields
        private DateTime dateAndTime;
        private string dialedNumber;
        private TimeSpan? duration;

        public bool Equals(Call other)
        {
            if ((this.DateAndTime == other.DateAndTime) && (this.DialedNumber == other.DialedNumber) && (this.Duration == other.Duration))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Properties to encapsulate the fields
        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }
            set
            {
                this.dateAndTime = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            set
            {
                this.dialedNumber = value;
            }
        }

        public TimeSpan? Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        // Constructors
        // Main constructor
        public Call(DateTime dateAndTime, string dialedNumber, TimeSpan? duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public Call()
            : this(new DateTime(), null, null)
        {
        }

        // Represent calls as string
        public override string ToString()
        {
            StringBuilder call = new StringBuilder();
            call.AppendFormat("Timestamp: {0}", this.DateAndTime);
            call.AppendFormat("\r\nNumber:    {0}", this.DialedNumber);
            call.AppendFormat("\r\nDuration:  {0}", this.Duration);
            return call.ToString();
        }
    }
}
