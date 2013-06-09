using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHTML
{
    static void Main()
    {
        Console.WriteLine("This program will read an HTML file and extract everything except the tags and their properties from it.");

        // Input
        Console.WriteLine("Enter the path to the HTML file:");
        string path = Console.ReadLine();

        StringBuilder builder = new StringBuilder();
        // Read the file and write it to a string
        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            builder.Append(reader.ReadToEnd());
        }
        string html = builder.ToString();
        
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            // Extract the title and write it
            writer.WriteLine("Title: {0}", Regex.Match(html, "<title>(.*?)</title>").Groups[1].ToString());
            writer.WriteLine();
            writer.WriteLine("Body:");
            // Extract the body (I do this in two parts - split by <body> first, and then split the resulting string by </body>)
            string afterHead=Regex.Split(html, "<body[^>]*>").GetValue(1).ToString();
            string body = Regex.Split(afterHead, "<body[^>]*>").GetValue(0).ToString();

            // For each text within the body which is between > and < (e.g. outside of a tag), write it to the file
            foreach (Match match in Regex.Matches(body, ">(.*?)<"))
            {
                writer.WriteLine(match.Groups[1].ToString());
            }
        }
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}