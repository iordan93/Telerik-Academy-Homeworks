using System;

    class EscapingSequences
    {
        static void Main()
        {
            string backslash = "The \"use\" of quotations causes difficulties.";
            string at = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(backslash);
            Console.WriteLine(at);
        }
    }
