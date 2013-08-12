namespace _10.GetTotalIncomeByNameAndPeriod
{
    using System;
    using System.Linq;
    using NorthwindModel;

    public class GetTotalIncomeByNameAndPeriod
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                // This procedure is saved in the database and the model now contains it

                //northwind.Database.ExecuteSqlCommand(
                //                                     "CREATE PROCEDURE usp_FindTotalIncome (@startDate INT,  @endDate INT, @companyName NVARCHAR(100)) " +
                //                                     "AS " +
                //                                      "SELECT SUM(od.Quantity * od.UnitPrice) AS [Income] " +
                //                                      "FROM Suppliers s JOIN Products p " +
                //                                          "ON s.SupplierID = p.SupplierID " +
                //                                              "JOIN [Order Details] od " +
                //                                                  "ON od.ProductID = p.ProductID " +
                //                                                      "JOIN Orders o " +
                //                                                          "ON od.OrderID = o.OrderID " +
                //                                      "WHERE s.CompanyName = @companyName AND (YEAR(o.OrderDate) >= @startDate AND YEAR(o.OrderDate) <= @endDate)");
                //northwind.SaveChanges();

                var income = northwind.usp_FindTotalIncome(1997, 1998, "Exotic Liquids");
                Console.WriteLine("Total income: {0:F2}", income.FirstOrDefault());
            }
        }
    }
}
