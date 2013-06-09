using System;
using System.IO;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        Console.WriteLine("This program will download a file from the Internet.");

        Console.Write("Enter the URL to the file: ");
        string path = Console.ReadLine();
        int index = path.LastIndexOf('/');
        string fileName = path.Substring(index + 1);

        using (WebClient client = new WebClient())
        {
            try
            {
                client.DownloadFile(path, fileName);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path to the file must be valid.");
            }
            catch (WebException)
            {
                Console.WriteLine("A problem with the connection has ocurred. Check the URL of the file and try again.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("This operation is not supported. Try again.");
            }
        }
        Console.WriteLine("The file has been downloaded. Look for it in the \\bin\\Debug folder of the application.");
    }
}