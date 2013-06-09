using System;

namespace GSMData
{
    public class Display
    {
        // Fields
        private double? size;
        private int? numberOfColours;

        // Properties to encapsulate the fields
        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if ((value != null) && (value < 0))
                {
                    throw new ArgumentException("Display size must be non-negative!");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? NumberOfColours
        {
            get
            {
                return this.numberOfColours;
            }
            set
            {
                if ((value != null) && (value < 0))
                {
                    throw new ArgumentException("The display number of colours must be nonnegative!");
                }
                else
                {
                    this.numberOfColours = value;
                }
            }
        }

        // Main constructor (serves as empty constructor too)
        public Display(double? size = null, int? numberofColours = null)
        {
            this.Size = size;
            this.NumberOfColours = numberofColours;
        }
    }
}
