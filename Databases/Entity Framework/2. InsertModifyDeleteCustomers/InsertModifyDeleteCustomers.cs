namespace _2.InsertModifyDeleteCustomers
{
    using System;
    using System.Linq;
    using NorthwindModel;

    public class InsertModifyDeleteCustomers
    {
        public static string AddCustomer(NorthwindEntities northwind, Customer customer)
        {
            northwind.Customers.Add(customer);
            northwind.SaveChanges();

            return "Customer added";
        }

        public static string ModifyCustomerById(NorthwindEntities northwind, string customerId, Customer newCustomer)
        {
            var selectedCustomer = northwind.Customers.Where(c => c.CustomerID == customerId).FirstOrDefault();
            
            selectedCustomer.Address = newCustomer.Address;
            selectedCustomer.City = newCustomer.City;
            selectedCustomer.CompanyName = newCustomer.CompanyName;
            selectedCustomer.ContactName = newCustomer.ContactName;
            selectedCustomer.ContactTitle = newCustomer.ContactTitle;
            selectedCustomer.Country = newCustomer.Country;
            selectedCustomer.CustomerDemographics = newCustomer.CustomerDemographics;
            selectedCustomer.Fax = newCustomer.Fax;
            selectedCustomer.Orders = newCustomer.Orders;
            selectedCustomer.Phone = newCustomer.Phone;
            selectedCustomer.PostalCode = newCustomer.PostalCode;
            selectedCustomer.Region = newCustomer.Region;
            
            northwind.SaveChanges();

            return "Customer modified";
        }

        public static string DeleteCustomer(NorthwindEntities northwind, Customer newCustomer)
        {
            var selectedCustomer = northwind.Customers.Where(c => c.CustomerID == newCustomer.CustomerID).FirstOrDefault();
            northwind.Customers.Remove(selectedCustomer);
            northwind.SaveChanges();

            return "Customer deleted";
        }
    }
}
