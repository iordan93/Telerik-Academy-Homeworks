using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordStartWithFinish
{
    static void Main()
    {
        Console.WriteLine("This program will replace each word \"start\" with \"end\" in a file.");

        // To make the program work for big files, we need to read the file line by line
        Console.Write("Enter the path to the file to read: ");
        string path = Console.ReadLine();
        Console.Write("Enter the path to the file to create: ");
        string resultPath = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        StreamWriter writer = new StreamWriter(resultPath);
        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                // Read each line and if needed, replace the word "start" with "finish".
                // (To replace a whole word, we need to use a regular expression)
                while (line != null)
                {
                    string replaced = Regex.Replace(line, @"\bstart\b", "finish");
                    writer.WriteLine(replaced);
                    line = reader.ReadLine();
                }
            }
        }

        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}