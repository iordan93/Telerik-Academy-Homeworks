using System;
using System.IO;
using System.Security;

class ReadFile
    {
        static string ReadAFile(string path)
        {
            string file = string.Empty;
            try
            {
                file = File.ReadAllText(path);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter a valid path.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path you entered is not valid. Double check the path to the file and try again.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path to the file is too long. Try another file or read a copy.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("A directory is not found. Double check the path to the file and try again.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file has not been found. Enter a different path or try with a different file.");
            }
            catch (IOException)
            {
                Console.WriteLine("There was an error with the input or output. Restart the program and try reading the file again.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have sufficient privileges to open this file.");
            }
            catch (SecurityException)
            {
                Console.WriteLine("There was a security error. Try again.");
            }

            return file;
        }

        static void Main()
        {
            Console.WriteLine("This program will read the contents of a file and print it to the console.");

            Console.Write("Enter the full path to the file: ");
            string path = Console.ReadLine();
            
            Console.WriteLine(ReadAFile(path));
        }
    }