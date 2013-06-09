using System;
using System.IO;
using System.Text;

class ReplaceStartWithFinish
{
    static StringBuilder ReadFile()
    {
        Console.Write("Enter the path to the file to read: ");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            builder.Append(reader.ReadToEnd());
        }
        return builder;
    }

    static void WriteFile(string file)
    {
        Console.Write("Enter the path to the file to create: ");
        string path = Console.ReadLine();
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            writer.Write(file);
        }
    }
    
    static void Main()
    {
        Console.WriteLine("This program will replace each substring \"start\" with \"end\" in a file.");
        StringBuilder file = ReadFile();
        file.Replace("start", "finish");
        WriteFile(file.ToString());
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}