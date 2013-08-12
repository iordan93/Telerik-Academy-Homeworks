namespace _9.PlaceNewOrder
{
    using System;
    using System.Linq;
    using System.Transactions;
    using NorthwindModel;

    public class PlaceNewOrder
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                using (var scope = new TransactionScope())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        northwind.Orders.Add(new Order() { ShipAddress = "455, Metropolitan Avenue" });
                    }

                    northwind.SaveChanges();
                    scope.Complete();
                }

                Console.WriteLine("Number of added orders: {0}", northwind.Orders.Where(o => o.ShipAddress == "455, Metropolitan Avenue").Count());
            }
        }

        public static void AddOrder(NorthwindEntities northwind, Order order)
        {
            northwind.Orders.Add(order);
            northwind.SaveChanges();
        }
    }
}