using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class DisplayAllExecutableFiles
{
    private static readonly StringBuilder traversalOutput = new StringBuilder();

    public static void TraverseDirectory(string rootDirectory, string extension)
    {
        try
        {
            string[] innerDirectories = Directory.GetDirectories(rootDirectory);
            foreach (string directory in innerDirectories)
            {
                TraverseDirectory(directory, extension);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("There was a problem with opening a directory: {0}", ex.Message);
        }

        try
        {
            string[] files = Directory.GetFiles(rootDirectory);
            foreach (string file in files)
            {
                if (file.EndsWith(extension))
                {
                    traversalOutput.AppendLine(file);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            traversalOutput.AppendLine(string.Format("There was a problem with opening a file: {0}", ex.Message));
        }
    }

    public static void Main()
    {
        Console.Write("Enter the extension of the files to display: ");
        string extension = Console.ReadLine();
        if (extension.IndexOf('.') == -1)
        {
            extension = '.' + extension;
        }

        Console.Write("Enter the directory to start the traversal at: ");
        string rootDirectory = Console.ReadLine();
        if (rootDirectory.IndexOf('\\') == -1)
        {
            rootDirectory = rootDirectory + '\\';
        }

        TraverseDirectory(rootDirectory, extension);
        Console.WriteLine(traversalOutput.ToString());
    }
}
