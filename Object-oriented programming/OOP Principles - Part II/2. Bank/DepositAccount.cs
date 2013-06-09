using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class DepositAccount : Account, IDepositable, IWithdrawable
    {
        // Constructor
        public DepositAccount(CustomerType customerType, decimal balance, decimal interestRate, DateTime creationTime)
            : base(customerType, balance, interestRate, creationTime)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("The amount {0} has been deposited. The current balance is {1}.", amount, this.Balance);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance -= amount;
                Console.WriteLine("The amount {0} has been withdrawn. The current balance is {1}.", amount, this.Balance);
            }
            else throw new ArgumentException("The amount of money to withdraw cannot be greater than the current balance.");
        }

        public override decimal CalculateInterest()
        {
            if (this.Balance >= 1000)
            {
                return base.CalculateInterest();
            }
            else return 0;
        }
    }
}
