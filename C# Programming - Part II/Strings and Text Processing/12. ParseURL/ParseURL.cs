using System;
class ParseURL
{
    static void Main()
    {
        Console.WriteLine("This program will read and parse a given URL.");

        // Input
        Console.WriteLine("Enter the URL:");
        string url = Console.ReadLine();

        // Find "//" which denotes the end of the protocol, then find the first "/" after "//", which denotes the end of the server name
        int protocolEnd = url.IndexOf("//");
        int serverEnd = url.Substring(protocolEnd + 2).IndexOf("/");

        // Protocol: from the beginning to the first index of "//", inclusive (2 more characters)
        Console.WriteLine("Protocol: {0}",url.Substring(0, protocolEnd + 2));
        // Server: from the end of the protocol to the first index of "/"
        Console.WriteLine("Server: {0}", url.Substring(protocolEnd + 2, serverEnd));
        // Resource: the rest of the string
        Console.WriteLine("Resource: {0}", url.Substring(protocolEnd + 2 + serverEnd));
    }
}