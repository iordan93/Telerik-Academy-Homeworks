using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class SortAFileByNumberOfOccurrences
{
    // This is an extension of the previous exercise where the words are not replaced, but counted.
    static string ReadFile(string path)
    {
        StringBuilder file = new StringBuilder();
        try
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                file.Append(reader.ReadToEnd());
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path must not be null. Enter a valid path.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is wrong. Try again.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file has not been found. Try again.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("A folder has not been found. Try again.");
        }
        catch (IOException)
        {
            Console.WriteLine("An error ocurred during trying to read from the file. Please try again.");
        }
        return file.ToString();
    }

    // Read the file with forbidden words and make an array to hold them
    // Since we do not know the size of the array, we use List<string> first, and then convert it to array
    static string[] GetWords()
    {
        Console.Write("Enter the path to the file which contains the words to look for. The words must be separated by new lines: ");
        List<string> words = new List<string>();
        try
        {
            string path = Console.ReadLine();
            string file = ReadFile(path);
            words.AddRange(file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("There is not enough memory to read from the console. Please try again.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("An error occurred while trying to parse the list of words. Please try again.");
        }
        return words.ToArray();
    }

    static void WriteFile(string file, string path, string[] words, int[] count)
    {
        try
        {
            StreamWriter writer = new StreamWriter(path);
            using (writer)
            {
                for (int i = words.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine("{0}: {1}", words[i], count[i]);
                }
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path must not be null. Enter a valid path.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is wrong. Try again.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file has not been found. Try again.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("A folder has not been found. Try again.");
        }
        catch (IOException)
        {
            Console.WriteLine("An error ocurred during trying to read from the file. Please try again.");
        }
        catch (SecurityException)
        {
            Console.WriteLine("The requested operation might interfere with your system's security. Please try again with a different file.");
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("The stream you are trying to write to is already closed. Try again.");
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will read a file and check the occurrences of each word, specified in another file.");
        Console.Write("Enter the path to the file to read: ");
        string path = Console.ReadLine();
        // Read the file whose words should be counted
        string file = ReadFile(path);

        // Read the file with the words to look for and write it to an array
        string[] words = GetWords();

        // Make a new array to save the number of occurrences of each word
        // (This could also be implemented with Dictionary<string,int>, but it is easier with two arrays)
        int[] count = new int[words.Length];
        try
        {
            // For each whole word that matches one of the entries in the second file, increment the counter
            for (int i = 0; i < count.Length; i++)
            {
                count[i] += Regex.Matches(file, "\\b" + words[i] + "\\b").Count;
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The words were not replaced. Please try again.");
        }

        // Create a new file
        Console.Write("Enter the path to the file to write the result to: ");
        string resultPath = Console.ReadLine();
        
        // Sort the array, using count as key (e.g. sort words by their count in ascending order)
        Array.Sort(count, words);

        // Print the array in reversed (descending) order to the specified file
        WriteFile(file, resultPath, words, count);
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}