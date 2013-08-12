namespace _3.GetOrdersFromCanadaIn1997
{
    using System;
    using System.Linq;
    using NorthwindModel;

    public class GetOrdersFromCanadaIn1997
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                var orders = northwind.Orders.Where(o => o.ShipCountry == "Canada" && o.RequiredDate.Value.Year == 1997).ToList();
                foreach (var order in orders)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", order.CustomerID, order.Freight, order.ShipAddress, order.ShipRegion);
                }
            }
        }
    }
}
