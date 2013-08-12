namespace _6.CreateNorthwindTwin
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using NorthwindModel;

    public class CreateNorthwindTwin
    {
        public static void Main()
        {
            IObjectContextAdapter dataBase = new NorthwindEntities();
            string cloneNorthwind = dataBase.ObjectContext.CreateDatabaseScript();

            SqlConnection connection = new SqlConnection("Server=.\\; " +
                                                         "Database=master; Integrated Security=true");
            connection.Open();
            using (connection)
            {
                SqlCommand createDatabase = new SqlCommand(
                                                           "USE master; " +
                                                           "CREATE DATABASE NorthwindTwin; " +
                                                           "SELECT name, size, size*1.0/128 AS [Size in MBs] " +
                                                           "FROM sys.master_files " +
                                                           "WHERE name = N'NorthwindTwin'; ", 
                                                           connection);
                createDatabase.ExecuteNonQuery();
                string changeDB = "USE NorthwindTwin; ";
                SqlCommand useNewDatabase = new SqlCommand(changeDB, connection);
                useNewDatabase.ExecuteNonQuery();
                SqlCommand cloneDatabase = new SqlCommand(cloneNorthwind, connection);
                cloneDatabase.ExecuteNonQuery();
            }
        }
    }
}