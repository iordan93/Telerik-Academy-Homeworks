namespace _8.ExtendedEmployee
{
    using System;
    using System.Data.Linq;
    using System.Linq;
    using NorthwindModel;

    public class ExtendedEmployee
    {
        public static void Main()
        {
            using (var northwind = new NorthwindEntities())
            {
                // To see the TerritoriesSet property, look in the model for the ExtendedEmployee class
                EntitySet<Territory> territories = northwind.Employees.OrderBy(t => t.EmployeeID).Skip(1).FirstOrDefault().TerritoriesSet;

                Console.WriteLine("Territory IDs:");
                Console.WriteLine(string.Join(Environment.NewLine, territories.Select(t => t.TerritoryDescription)));
            }
        }
    }
}
