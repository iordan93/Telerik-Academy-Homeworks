using System;
using System.Data.SqlClient;

public class AddNewProduct
{
    public static void Main()
    {
        Console.Write("Enter the name of the product: ");
        string productName = Console.ReadLine();
        Console.Write("Enter the category ID of the product: ");
        int categoryId = int.Parse(Console.ReadLine());
        Console.Write("Is the product discontinued? Yes / No: ");
        string discontinuedAsString = Console.ReadLine();
        byte discontinued = 0;
        if (discontinuedAsString.ToLower() == "yes")
        {
            discontinued = 1;
        }
        else if (discontinuedAsString.ToLower() == "no")
        {
            discontinued = 0;
        }
        else
        {
            throw new ArgumentException("The input for product discontinuation is wrong. It should be \"Yes\" ot \"No\".");
        }

        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");
        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Products (ProductName, CategoryId, Discontinued)" +
                "VALUES (@ProductName, @CategoryId, @Discontinued)",
                connection);
            command.Parameters.AddWithValue("@ProductName", productName);
            command.Parameters.AddWithValue("@CategoryId", categoryId);
            command.Parameters.AddWithValue("@Discontinued", discontinued);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ErrorCode + ":" + ex.Message);
            }
        }
    }
}
