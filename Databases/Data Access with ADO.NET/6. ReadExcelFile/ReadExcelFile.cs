using System;
using System.Data.OleDb;

public class ReadExcelFile
{
    public static void Main()
    {
        string excelFile = "../../../Scores.xlsx";
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" +
            excelFile +
            "; Extended Properties=\"Excel 12.0 Xml; HDR=YES\"");
        connection.Open();
        using (connection)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Scores$]", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Name: " + reader["Name"] + "; Score: " + reader["Score"]);
            }
        }
    }
}