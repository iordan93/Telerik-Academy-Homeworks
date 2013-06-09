using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class DeleteOddLines
{
    // Get each line and if it is odd, add it to a list
    static List<string> GetOddLines(StreamReader reader)
    {
        string line = string.Empty;
        List<string> oddLines = new List<string>();
        using (reader)
        {
            line = reader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    oddLines.Add(line);
                }
                line = reader.ReadLine();
            }
        }
        return oddLines;
    }

    // Write each string of the list of odd lines
    static void WriteFile(string path, List<string> oddLines)
    {
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            foreach (string item in oddLines)
            {
                writer.WriteLine(item);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will remove all odd lines from a file and save the result in the same file.");
        Console.Write("Enter the path to the file to read and write to: ");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        List<string> oddLines = GetOddLines(reader);
        WriteFile(path, oddLines);

        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}
