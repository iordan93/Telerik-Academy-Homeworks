using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExtractTagsFromXMLFile
{
    static string ReadFile(string path)
    {
        StreamReader reader = new StreamReader(path);
        StringBuilder file = new StringBuilder();
        using (reader)
        {
            file.Append(reader.ReadToEnd());
        }
        return file.ToString();
    }

    static void WriteFile(string file, string path)
    {
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            writer.Write(file);
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will remove each tag from an XML file and write it to the same file.");
        Console.Write("Enter the path to the file to read and write to: ");
        string path = Console.ReadLine();
        string file = ReadFile(path);
        int openIndex = file.IndexOf("<");
        int closeIndex = file.IndexOf(">");
        while (openIndex >= 0)
        {
            file = file.Remove(openIndex, closeIndex - openIndex + 1);
            openIndex = file.IndexOf("<");
            closeIndex = file.IndexOf(">");
        }

        WriteFile(file.ToString(), path);

        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}