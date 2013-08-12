namespace _7.ConcurrentChanges
{
    using System;
    using System.Linq;
    using System.Transactions;
    using NorthwindModel;

    public class ConcurrentChanges
    {
        public static void Main()
        {
            using (var northwind1 = new NorthwindEntities())
            {
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = IsolationLevel.Serializable;
                using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    using (var northwind2 = new NorthwindEntities())
                    {
                        Customer customer = northwind1.Customers.FirstOrDefault();

                        customer.Country = "NewCountry";

                        Customer customer2 = northwind2.Customers.FirstOrDefault();
                        northwind1.SaveChanges();

                        Console.WriteLine("First connection country ->" + customer.Country);
                        Console.WriteLine("Second connection country ->" + customer2.Country);
                        Console.WriteLine("The second connection works with the old data - dirty read.");
                        scope.Complete();
                    }
                }
            }
        }
    }
}
