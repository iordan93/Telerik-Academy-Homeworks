using System;
using System.IO;
using System.Text;

class InsertLineNumbers
{
    static void Main()
    {
        Console.WriteLine("This program will read a file, add line numbers to each line, and write to another file.");
        
        // Read a file from a specified path
        Console.Write("Enter the path to the file you want to read: ");
        string path = Console.ReadLine();
        StringBuilder builder = new StringBuilder();
        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                // Append the line number to each line and save the result in a StringBuilder object to save memory
                lineNumber++;
                builder.AppendLine(String.Format("{0} {1}", lineNumber, line));
                line = reader.ReadLine();
            }
        }

        // Write the resulting string to a new file
        Console.Write("Enter the path to the file you want to write to: ");
        string resultPath = Path.GetFullPath(Console.ReadLine());
        StreamWriter writer = new StreamWriter(resultPath);
        using (writer)
        {
            writer.Write(builder.ToString());
        }

        // Give feedback to the user if everything went well
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}
