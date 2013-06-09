using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.People
{
    public class Worker : Human
    {
        // Private fields - firstName and lastName are inherited from Human
        private decimal weekSalary;
        private int workHoursPerDay;

        // Public properties to encapsulate the fields - FirstName and LastName are inherited from Human
        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        // Constructors
        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName)
            : this(firstName, lastName, 0, 0)
        {
        }

        // Methods
        public decimal MoneyPerHour()
        {
            // I suppose that a normal week consists of five workdays
            return this.WeekSalary / (5 * this.WorkHoursPerDay);
        }

        // Write the worker in a human-readable way
        public override string ToString()
        {
            StringBuilder worker = new StringBuilder();
            worker.AppendFormat("{0} Worker {0}\r\n",new string('=', 10));
            worker.AppendFormat("Name: {0} {1}\r\nSalary: {2}\r\nWork hours per day: {3}", this.FirstName,this.LastName, this.WeekSalary, this.WorkHoursPerDay);
            return worker.ToString();
        }
    }
}
