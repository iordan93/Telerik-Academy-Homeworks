using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ConsoleJustification
{
    static void Main()
    {
        short lines = short.Parse(Console.ReadLine());
        short charsPerLine = short.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();
        List<string> words = new List<string>();
        string input = string.Empty;
        for (int i = 0; i < lines; i++)
        {
            input = Console.ReadLine().Trim();
            input = Regex.Replace(input, "\\s{2,}", " ");
            string[] wordsLine = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            words.AddRange(wordsLine);
            //Console.WriteLine(input);
            sb.Append(input);
        }
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < charsPerLine; i++)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
        input.Remove(0, charsPerLine);
        for (int i = 0; i < charsPerLine; i++)
        {
            if (input.Length < charsPerLine)
            {
                Console.WriteLine(-1);
            }
        }

        for (int i = 0; i < length; i++)
        {
            
        }
    }
}
