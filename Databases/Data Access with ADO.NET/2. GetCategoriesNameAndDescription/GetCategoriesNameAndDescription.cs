using System;
using System.Data.SqlClient;

public class GetCategoriesNameAndDescription
{
    public static void Main()
    {
        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");

        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT CategoryName, Description FROM Categories", connection);
            SqlDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine("{0, -15}| {1}", result["CategoryName"], result["Description"]);
            }
        }
    }
}
