using System;
using MySql.Data.MySqlClient;

public class Books
{
    public static void Main()
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost; Uid = root; Pwd = 931118;");
        connection.Open();

        using (connection)
        {
            MySqlCommand createTable = new MySqlCommand(
                "CREATE SCHEMA IF NOT EXISTS `Books`;" +
                "USE `Books`;" +
                "CREATE TABLE IF NOT EXISTS `Books` ( " +
                    "BookId int PRIMARY KEY AUTO_INCREMENT," +
                    "Title VARCHAR(100) NOT NULL," +
                    "Author VARCHAR(100) NOT NULL," +
                    "PublishDate date NOT NULL, " +
                    "Isbn CHAR(13) NOT NULL " +
                ")",
                connection);
            createTable.ExecuteNonQuery();
            Console.WriteLine("The table \"Books\" has been created");

            AddBook(connection, "Introduction to programming with C#", "Nakov, Svetlin et al.", new DateTime(2011, 1, 1), "9789544005276");
            AddBook(connection, "Introduction to programming with Java", "Nakov, Svetlin et al.", new DateTime(2009, 1, 1), "9789544000554");
            ListAllBooks(connection);
            FindBookByName(connection, "C#");
        }
    }

    private static void FindBookByName(MySqlConnection connection, string name)
    {
        MySqlCommand selectProducts = new MySqlCommand("SELECT Title, Author, PublishDate, Isbn FROM Books WHERE Title LIKE @name", connection);
        selectProducts.Parameters.AddWithValue("@name", "%" + name.Replace("%", "[%]").Replace("_", "[_]") + "%");

        MySqlDataReader result = selectProducts.ExecuteReader();

        using (result)
        {
            Console.WriteLine("Search results:");
            while (result.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", result["Title"], result["Author"], result["PublishDate"], result["Isbn"]);
            }
        }
    }

    private static void ListAllBooks(MySqlConnection connection)
    {
        MySqlCommand getAllBooks = new MySqlCommand("SELECT Title, Author, PublishDate, Isbn FROM Books", connection);

        MySqlDataReader result = getAllBooks.ExecuteReader();

        using (result)
        {
            Console.WriteLine("All books:");
            while (result.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", result["Title"], result["Author"], result["PublishDate"], result["ISBN"]);
            }
        }
    }

    private static void AddBook(MySqlConnection connection, string title, string author, DateTime publishDate, string isbn)
    {
        MySqlCommand insertIntoProducts = new MySqlCommand(
            "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
            "VALUES (@Title, @Author, @PublishDate, @ISBN)",
            connection);
        insertIntoProducts.Parameters.AddWithValue("@Title", title);
        insertIntoProducts.Parameters.AddWithValue("@Author", author);
        insertIntoProducts.Parameters.AddWithValue("@PublishDate", publishDate.ToString("yyyy-MM-dd"));
        insertIntoProducts.Parameters.AddWithValue("@ISBN", isbn);
        insertIntoProducts.ExecuteNonQuery();

        Console.WriteLine("Book added");
    }
}