using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class MortgageAccount : Account, IDepositable
    {
        // Constructor
        public MortgageAccount(CustomerType customerType, decimal balance, decimal interestRate, DateTime creationTime)
            : base(customerType, balance, interestRate, creationTime)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("The amount {0} has been deposited. The current balance is {1}.", amount, this.Balance);
        }

        public override decimal CalculateInterest()
        {
            // Half interest for individuals the first 6 months and companies the first 12 months
            if ((this.CustomerType == CustomerType.Company) && ((DateTime.Now - CreationTime).Days / 30 <= 12) ||
                (this.CustomerType == CustomerType.Individual) && ((DateTime.Now - CreationTime).Days / 30 <= 6))
            {
                return base.CalculateInterest() / 2;
            }
            else return base.CalculateInterest();
        }
    }
}
