using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("This program will concatenate two text files into another text file.");
        Console.Write("Enter the path to the first file: ");
        string firstPath = Console.ReadLine();
        StreamReader reader = new StreamReader(firstPath);
        string firstFile = string.Empty;
        using (reader)
        {
            firstFile  = reader.ReadToEnd();
        }
        Console.Write("Enter the path to the second file: ");
        string secondPath = Console.ReadLine();
        reader = new StreamReader(secondPath);
        string secondFile = string.Empty;
        using (reader)
        {
            secondFile = reader.ReadToEnd();
        }
        Console.Write("Enter the path to the file you want to write: ");
        string resultPath = Path.GetFullPath(Console.ReadLine());
        StreamWriter writer = new StreamWriter(resultPath);
        using (writer) 
        {
            writer.Write(firstFile + secondFile);
        }
        Console.WriteLine("The files have been concatenated. Look for the result file in the path you specified.");
    }
}