using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class LoanAccount : Account, IDepositable
    {
        // Constructor
        public LoanAccount(CustomerType customerType, decimal balance, decimal interestRate, DateTime creationTime)
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
            // No interest for individuals the first 3 months and companies the first 2 months
            if ((this.CustomerType == CustomerType.Company) && ((DateTime.Now - CreationTime).Days / 30 <= 2) ||
                (this.CustomerType == CustomerType.Individual) && ((DateTime.Now - CreationTime).Days / 30 <= 3))
            {
                return 0;
            }
            return base.CalculateInterest();
        }
    }
}
