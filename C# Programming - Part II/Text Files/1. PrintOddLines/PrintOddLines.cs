using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        Console.WriteLine("This program will read a file and print its odd lines.");
        Console.Write("Enter the path to the file: ");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine("{0} {1}", lineNumber, line);
                }
                line = reader.ReadLine();
            }
        }
    }
}