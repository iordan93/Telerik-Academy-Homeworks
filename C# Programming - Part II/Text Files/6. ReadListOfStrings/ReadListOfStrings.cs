using System;
using System.IO;
using System.Text;

class ReadListOfStrings
{
    static string ReadFile()
    {
        Console.Write("Enter the path to the file to read: ");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            builder.Append(reader.ReadToEnd());
        }
        return builder.ToString();
    }

    static void WriteFile(string[] file)
    {
        Console.Write("Enter the path to the file to create: ");
        string path = Console.ReadLine();
        StreamWriter writer = new StreamWriter(path);
        // Write each line to a file, after the array has been sorted
        using (writer)
        {
            for (int line = 1; line <= file.Length; line++)
            {
                writer.WriteLine(file[line-1]);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will read a list of strings, sort it alphabetically, and save the sorted list in a new file.");
        string file = ReadFile();
        string[] list = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(list);
        WriteFile(list);
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}