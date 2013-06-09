using System;

namespace GSMData
{
    public enum BatteryType
    {
        None,
        LiIon,
        NiMH,
        NiCd
    }

    public class Battery
    {
        // Fields
        private string model;
        private ushort? hoursTalk;
        private ushort? hoursIdle;

        // Properties to encapsulate the fields
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public ushort? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if ((value != null) && (value < 0))
                {
                    throw new ArgumentException("The battery hours in talking mode must be nonnegative!");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public ushort? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if ((value != null) && (value < 0))
                {
                    throw new ArgumentException("The battery hours in idle mode must be nonnegative!");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public BatteryType BatType;

        // Constructors - model is mandatory
        // Main constructor
        public Battery(string model, ushort? hoursIdle = null, ushort? hoursTalk = null, BatteryType batteryType=BatteryType.None)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatType = batteryType;
        }

        // Empty constructor
        public Battery() : this("")
        {
        }
    }
}