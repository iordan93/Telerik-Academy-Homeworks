using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

class RemoveSpecifiedWords
{
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
        Console.Write("Enter the path to the file which contains the \"forbidden\" words. The words must be separated by new lines: ");
        List<string> words=new List<string>();
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
        catch(ArgumentException) 
        {
            Console.WriteLine("An error occurred while trying to parse the list of forbidden words. Please try again.");
        }
        return words.ToArray();
    }

    static void WriteFile(string file, string path)
    {
        try
        {
            StreamWriter writer = new StreamWriter(path);
            using (writer)
            {
                writer.Write(file);
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
        Console.WriteLine("This program will read a file and remove each word, specified in another file.");
        Console.Write("Enter the path to the file to read: ");
        string path = Console.ReadLine();
        string file = ReadFile(path);
        string[] forbiddenWords = GetWords();
        try
        {
            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                file = file.Replace(forbiddenWords[i], String.Empty);
            }
        }
        catch (ArgumentException) 
        {
            Console.WriteLine("The forbidden words were not replaced. Please try again.");
        }

        WriteFile(file, path);
        Console.WriteLine("The file has been written. Look for it in the path you specified.");
    }
}