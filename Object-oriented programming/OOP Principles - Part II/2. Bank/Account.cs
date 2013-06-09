using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public abstract class Account
    {
        // Proate fields
        private CustomerType customerType;
        private decimal balance;
        private decimal interestRate;
        private DateTime creationTime;

        // Public properties to encapsulate the fields
        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }
            protected set
            {
                this.customerType = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            protected set
            {
                if (value >= 0)
                {
                    this.interestRate = value;
                }
                else throw new ArgumentException("The interest rate of an account cannot be negative.");
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return this.creationTime;
            }
            protected set
            {
                if (value <= DateTime.Now)
                {
                    this.creationTime = value;
                }
                else throw new ArgumentException("The creation time of the account must be before the present moment.");
            }
        }

        // Constructor
        // Normally, the creation time should be automatically set to DateTime.Now but this will allow us to test the various accounts
        public Account(CustomerType customerType, decimal balance, decimal interestRate, DateTime creationTime)
        {
            this.CustomerType = customerType;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.CreationTime = creationTime;
        }

        // The default behaviour of the CalculateInterest() method is to return the days / 30 (the usual way banks calculate number of months), 
        // multiplied by the monthly interest rate
        public virtual decimal CalculateInterest()
        {
            return ((DateTime.Now - this.CreationTime).Days / 30) * this.InterestRate;
        }
    }
}
