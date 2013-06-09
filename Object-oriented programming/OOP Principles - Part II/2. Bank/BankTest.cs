using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class BankTest
    {
        static void Main()
        {
            // Create some accounts
            Account[] accounts = {
                                    new DepositAccount(CustomerType.Company, 1000M, 5.5M, new DateTime(2005, 5, 6)),
                                    new DepositAccount(CustomerType.Individual, 1200M, 8.3M, new DateTime(2009, 10, 2)),

                                    new LoanAccount(CustomerType.Company, 20000M, 7.2M, new DateTime(2012, 3, 5)),
                                    new LoanAccount(CustomerType.Individual, 10000M, 5.9M, new DateTime(2012, 8, 20)),

                                    new MortgageAccount(CustomerType.Company, 150000M, 8.3M, new DateTime(2010, 5, 14)),
                                    new MortgageAccount(CustomerType.Individual, 50000M, 7.4M, new DateTime(2012, 8, 25))
                                 };

            // Print each account's interest
            Console.WriteLine("Interests:");
            foreach (var item in accounts)
            {
                Console.WriteLine("* {0:C}", item.CalculateInterest());
            }
        }
    }
}
