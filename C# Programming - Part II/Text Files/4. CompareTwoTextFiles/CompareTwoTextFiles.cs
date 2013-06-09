using System;
using System.IO;

class CompareTwoTextFiles
{
    static void Main()
    {
        Console.WriteLine("This program will compare two text files line by line, assuming they have the same number of lines.");
        Console.Write("Enter the path to the first file: ");
        string firstPath = Console.ReadLine();
        Console.Write("Enter the path to the second file: ");
        string secondPath = Console.ReadLine();

        StreamReader firstReader = new StreamReader(firstPath);
        string firstLine = string.Empty;
        StreamReader secondReader = new StreamReader(secondPath);
        string secondLine = string.Empty;
        
        // Read one line from both lines
        firstLine = firstReader.ReadLine();
        secondLine = secondReader.ReadLine();
        int counterSame = 0;
        int counterDif = 0;
        while ((firstLine != null) && (secondLine != null))
        {
            // Count how many lines are the same and how many are different and read the next lines
            if (firstLine == secondLine)
            {
                counterSame++;
            }
            else
            {
                counterDif++;
            }
            firstLine = firstReader.ReadLine();
            secondLine = secondReader.ReadLine();
        }

        // Close the streams
        firstReader.Dispose();
        secondReader.Dispose();

        // Output
        Console.WriteLine("Same lines: {0}; Different lines: {1}", counterSame, counterDif);
    }
}