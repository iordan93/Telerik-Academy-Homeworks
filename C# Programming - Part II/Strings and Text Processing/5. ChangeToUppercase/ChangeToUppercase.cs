using System;
class ChangeToUppercase
{
    static void Main()
    {
        Console.WriteLine("This program will change all text surrounded by <upcase> </upcase> to uppercase.");

        // Input
        Console.WriteLine("Enter the expression to rewrite:");
        string input = Console.ReadLine();
        
        string upcase = "<upcase>";
        string closeUpcase = "</upcase>";

        // While there are still <upcase> tags (IndexOf returns a number, different than -1), see where the opening and closing tags begin.
        // Extract the string to convert to uppercase and replace it with its equivalent in uppercase, removing the <upcase></upcase> tags.
        while (input.IndexOf(upcase) != -1)
        {
            int start = input.IndexOf(upcase);
            int end = input.IndexOf(closeUpcase);
            string changeToUppercase = input.Substring(start + upcase.Length, end - start - upcase.Length);
            input = input.Replace(upcase + changeToUppercase + closeUpcase, changeToUppercase.ToUpper());
        }

        // Output
        Console.WriteLine(input);
    }
}
