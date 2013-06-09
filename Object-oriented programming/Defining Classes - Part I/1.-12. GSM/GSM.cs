using System;
using System.Collections.Generic;
using System.Text;

namespace GSMData
{
    public class GSM
    {
        // Instance fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private List<Call> callHistory = new List<Call>();

        // Static fields
        private static readonly GSM IPhone4s = new GSM("Apple", "iPhone 4S", new Battery("Apple", 100, 2, BatteryType.LiIon), new Display(5.5, 16000000), 1000);
        private static decimal pricePerMinute = 0.37M;

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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        // Static properties - not connected to an instance
        public static GSM IPhone4S
        {
            get
            {
                return IPhone4s;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return callHistory;
            }
            set
            {
                callHistory = value;
            }
        }

        // Constructors - model and manufacturer are mandatory, the other parameters are optional,
        // so it is best to set default values for them
        // Main constructor - others inherit from it
        public GSM(string manufacturer, string model, Battery battery = null, Display display = null, decimal price = 0, string owner = null)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        // Manufacturer model and price; no owner set
        public GSM(string manufacturer, string model, decimal price)
            : this(manufacturer, model, battery: null, price: price)
        {
        }

        // Manufacturer, model and owner; no price set
        public GSM(string manufacturer, string model, string owner)
            : this(manufacturer, model, battery: null, owner: owner)
        {
        }

        // No owner or price
        public GSM(string manufacturer, string model, Battery battery, Display display)
            : this(manufacturer, model, battery, display, 0, null)
        {
        }

        // Empty constructor
        public GSM()
            : this("", "")
        {
        }

        // Write the GSM as string
        public override string ToString()
        {
            StringBuilder gsm = new StringBuilder();
            gsm.AppendFormat("========== {0} {1} ==========", this.Manufacturer, this.Model);
            gsm.AppendFormat("\r\nPrice: {0} lv.", this.Price);
            gsm.AppendFormat("\r\nOwner: {0}", this.Owner);
            if (this.Battery != null)
            {
                gsm.AppendFormat("\r\n---------- Battery ----------");
                gsm.AppendFormat("\r\nModel: {0}", this.Battery.Model);
                gsm.AppendFormat("\r\nHours in idle mode: {0} h", this.Battery.HoursIdle);
                gsm.AppendFormat("\r\nHours in talking mode: {0} h", this.Battery.HoursTalk);
            }
            if (this.Display != null)
            {
                gsm.AppendFormat("\r\n---------- Display ----------");
                gsm.AppendFormat("\r\nSize: {0} inches", this.Display.Size);
                gsm.AppendFormat("\r\nNumber of colours: {0}", this.Display.NumberOfColours);
            }
            return gsm.ToString();
        }

        // Instance methods
        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculatePrice()
        {
            decimal price = 0;
            foreach (Call call in this.CallHistory)
            {
                // If the seconds are less than 30, they are rounded down to calculate the price,
                // if they are more than 30, they are rounded up
                if (call.Duration.Value.Seconds <= 30)
                {
                     price += (call.Duration.Value.Hours*60 + call.Duration.Value.Minutes) * pricePerMinute;
                }
                else
                {
                    price += (call.Duration.Value.Hours * 60 + call.Duration.Value.Minutes + 1) * pricePerMinute;
                }
            }
            return price;
        }
    }
}
