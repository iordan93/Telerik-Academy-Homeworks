using System;
using System.Data.SqlClient;

public class GetCategoriesAndProducts
{
    public static void Main()
    {
        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");

        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p " +
                    "ON p.CategoryId = c.CategoryId " +
                "ORDER BY c.CategoryName", 
                connection);
            SqlDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine("{0, -15}| {1}", result["CategoryName"], result["ProductName"]);
            }
        }
    }
}
