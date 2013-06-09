using System;
using System.Linq;
using System.Text.RegularExpressions;

class ReplaceAnchorsWithURLs
{
    static void Main()
    {
        Console.WriteLine("This program will replace each <a href=\"...\">... </a> tag with [URL=...]...[/URL] in a given user input.");
        
        // Input
        Console.WriteLine("Enter the string whose links to format:");
        string input = Console.ReadLine();
        
        // The regular expression takes everything between <a href="(1)"> (2) </a> and replaces it with [URL=(1)](2)[/URL]
        // (The $ sign refers to string replacement (backreferences)) and mean, respectively: $1 - first matched group, $2 - second matched group
        string output = Regex.Replace(input, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]");

        // Output
        Console.WriteLine(output);
    }
}