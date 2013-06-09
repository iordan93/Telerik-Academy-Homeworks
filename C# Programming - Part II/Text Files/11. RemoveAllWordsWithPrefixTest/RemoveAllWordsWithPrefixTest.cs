using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class RemoveAllWordsWithPrefixTest
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
        Console.WriteLine("This program will remove each word that starts with the prefix \"test\" from a given text file.");
        Console.Write("Enter the path to the file to read and write to: ");
        string path = Console.ReadLine();
        string file = ReadFile(path);
        
        // The regular expression will remove each word that contains letters, numbers, and underscores (\w),
        // starts with "test" (\btest) and is has at least one more symbol {1,}, 
        // e.g. the word "test" does not have prefix "test".
        file = Regex.Replace(file, @"\btest\w{1,}", String.Empty);
        WriteFile(file, path);

        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}
