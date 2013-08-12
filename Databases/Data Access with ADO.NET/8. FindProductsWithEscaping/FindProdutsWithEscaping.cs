using System;
using System.Data.SqlClient;

public class FindProdutsWithEscaping
{
    public static void Main()
    {
        // To test, add a product with ProductName "10%" for example and search for "10%"
        Console.Write("Enter the phrase to search products for: ");
        string search = Console.ReadLine();

        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");

        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT ProductName FROM Products WHERE ProductName LIKE @search",
                connection);
            command.Parameters.AddWithValue("@search", "%" + search.Replace("%", "[%]").Replace("_", "[_]") + "%");
            SqlDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine(result["ProductName"]);
            }
        }
    }
}
