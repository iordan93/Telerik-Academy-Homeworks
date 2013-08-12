using System;
using System.Data.OleDb;

public class ReadExcelFile
{
    public static void Main()
    {
        Console.Write("Enter the name of the person: ");
        string name = Console.ReadLine();
        Console.Write("Enter the score of the person: ");
        int score = int.Parse(Console.ReadLine());

        string excelFile = "../../../Scores.xlsx";
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" +
            excelFile +
            "; Extended Properties=\"Excel 12.0 Xml; HDR=YES\"");
        connection.Open();
        using (connection)
        {
            OleDbCommand command = new OleDbCommand("INSERT INTO [Scores$] (Name, Score) VALUES (@name, @score)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data);
            }
        }

        Console.WriteLine("The score has been added to the table.");
    }
}