using System;
using System.Data.SqlClient;

public class GetRowsInCategoriesTable
{
    public static void Main()
    {
        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");

        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", connection);
            int result = (int)command.ExecuteScalar();
            Console.WriteLine("There are {0} categories.", result);
        }
    }
}
