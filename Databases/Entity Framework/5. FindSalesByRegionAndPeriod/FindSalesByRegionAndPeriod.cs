namespace _5.FindSalesByRegionAndPeriod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NorthwindModel;

    public class FindSalesByRegionAndPeriod
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                var a = northwind.Orders.Select(o => o.ShipRegion).ToList();
                List<string> sales = FindSales(northwind, 1997, "RJ");

                Console.WriteLine(string.Join(Environment.NewLine, sales));
            }
        }

        public static List<string> FindSales(NorthwindEntities northwind, int year, string region)
        {
            List<string> sales = northwind.Orders.Join(northwind.Customers, o => o.CustomerID, c => c.CustomerID, (o, c) => new
            {
                CompanyName = c.CompanyName,
                OrderDate = o.OrderDate,
                ShipCountry = o.ShipCountry,
                ShipRegion = o.ShipRegion
            }).Where(x => x.ShipRegion == region && year.CompareTo(x.OrderDate.Value.Year) == 0).Select(y => y.CompanyName).
            ToList();

            return sales;
        }
    }
}