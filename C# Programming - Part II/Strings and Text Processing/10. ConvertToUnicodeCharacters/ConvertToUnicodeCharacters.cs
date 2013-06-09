using System;
class ConvertToUnicodeCharacters
{
    static void Main()
    {
        Console.WriteLine("This program will read a string and convert it to its Unicode character equivalent.");

        // Input
        Console.WriteLine("Enther the string to convert:");
        string toConvert = Console.ReadLine();

        // Unicode uses 16-bit representation of symbols. To see each symbol's representation, we convert the integer, corresponding to it
        // to hexadecimal system using String.Format(), and append \u at the front. Then we print the symbol
        for (int i = 0; i < toConvert.Length; i++)
        {
            string currentSymbol=String.Format("\\u{0:X4}", (int)toConvert[i]);
            Console.Write(currentSymbol);
        }
        Console.WriteLine();
    }
}
