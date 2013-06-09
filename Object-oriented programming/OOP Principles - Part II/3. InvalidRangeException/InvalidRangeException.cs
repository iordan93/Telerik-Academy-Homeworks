using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    class InvalidRangeException<T> : ArgumentException
    {
        // Private fields - start and end of the range
        private T start;
        private T end;
        private string argument;

        // Public properties to encapsulate the fields
        public T Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }

        public string Argument
        {
            get
            {
                return this.argument;
            }
            set
            {
                this.argument = value;
            }
        }

        // Constructor
        public InvalidRangeException(T start, T end)
            : base(String.Format("The argument was not in the specified range ({0}, {1})", start, end))
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(T start, T end, string argument)
            : base(String.Format("The argument {0} was not in the specified range ({1}, {2})", argument, start, end))
        {
            this.Start = start;
            this.End = end;
            this.Argument = argument;
        }
    }
}
