namespace _4.GetOrdersNativeQuery
{
    using System;
    using System.Linq;
    using NorthwindModel;

    public class GetOrdersNativeQuery
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                string command = @"SELECT c.ContactName from Customers c " +
                                "INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                                "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

                object[] parameters = { 1997, "Canada" };
                var sqlQueryResult = northwind.Database.SqlQuery<string>(command, parameters);

                foreach (var order in sqlQueryResult)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
}
