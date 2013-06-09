using System;

class PrintASCIICharacters
{
    static void Main()
    {
        for (char i = ' '; i <= 255; i++)
        {
            char character = (char)i;
            Console.Write(character + "\t");
        }
        Console.WriteLine((char)128);
    }
}
