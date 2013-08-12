using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class GetImages
{
    public static void Main()
    {
        SqlConnection connection = new SqlConnection("Server=.\\;Database=Northwind;Integrated Security=true");

        using (connection)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT CategoryName, Picture FROM Categories", connection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    if (categoryName.Contains("/") == true)
                    {
                        categoryName = categoryName.Replace('/', ' ');
                    }

                    byte[] pictureBytes = reader["Picture"] as byte[];

                    // Skip first 78 bytes because it is header information
                    MemoryStream imageAsStream = new MemoryStream(pictureBytes, 78, pictureBytes.Length - 78);

                    Image image = Image.FromStream(imageAsStream);
                    using (image)
                    {
                        image.Save("../../" + categoryName + ".jpg", ImageFormat.Jpeg);
                    }
                }
            }
        }

        Console.WriteLine("Look for the images in the main program folder.");
    }
}