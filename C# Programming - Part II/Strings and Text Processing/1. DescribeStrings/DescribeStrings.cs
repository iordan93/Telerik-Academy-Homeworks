using System;
class DescribeStrings
{
    static void Main()
    {
        Console.Write("Strings are a key component of all computer programs. Their main role is to keep a storage of symbols. ");
        Console.Write("A main characteristic of a string is its immutability, i.e. the string cannot be edited in-place. ");
        Console.Write("That is why it is important to remember that while performing operations over strings, a program actually ");
        Console.WriteLine("copies the string. This may lead to slower performance or even out of memory exception if strings are processed in loops.");
        Console.WriteLine();
        Console.WriteLine("Some useful methods of the String class are:");
        Console.WriteLine("String.Join() (which joins two or more string arrays together);");
        Console.WriteLine("String.Split() (which does the opposite of String.Join());");
        Console.WriteLine("String.Concat() (which concatenates two strings, like the + operator);");
        Console.WriteLine("String.Format() (which allows using formatting strings);");
        Console.WriteLine("String.Compare() (which compares two strings).");
        Console.WriteLine();
        Console.WriteLine("And the instance methods:");
        Console.WriteLine("Trim(), ToUpper(), ToLower(), IndexOf(), LastIndexOf(), ToCharArray(), Insert(), Remove(), Replace(), PadLeft(), and PadRight().");
        Console.WriteLine();
        Console.WriteLine("It is important to notice once more that the instance method work on a copy of the string, not the original one.");
    }
}
