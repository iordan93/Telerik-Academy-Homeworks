namespace _2.InsertModifyDeleteCustomers
{
    using System;
    using System.Linq;
    using NorthwindModel;

    public class InsertModifyDeleteCustomersTest
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                Customer customer = new Customer();
                customer.Address = "155, Madison Avenue";
                customer.City = "New York";
                customer.CompanyName = "Company";
                customer.Country = "United States";
                customer.CustomerID = "US123";
                customer.ContactName = "James Peterson";

                Console.WriteLine(InsertModifyDeleteCustomers.AddCustomer(northwind, customer));

                Customer anotherCustomer = new Customer();
                anotherCustomer.CustomerID = "US123";
                anotherCustomer.Address = "253, Madison Avenue";
                anotherCustomer.City = "New York";
                anotherCustomer.CompanyName = "Another company";
                anotherCustomer.Country = "United States";
                anotherCustomer.ContactName = "Peter Jameson";
                Console.WriteLine(InsertModifyDeleteCustomers.ModifyCustomerById(northwind, "COMPA", anotherCustomer));

                Console.WriteLine(InsertModifyDeleteCustomers.DeleteCustomer(northwind, anotherCustomer));
            }
        }
    }
}
