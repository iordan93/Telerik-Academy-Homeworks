using System;

    class CopyrightSymbols
    {
        static void Main()
        {
            char copyright='\u00a9';
            Console.WriteLine("  {0}",copyright);
            Console.WriteLine(" {0}{0}{0}",copyright);
            Console.WriteLine("{0}{0}{0}{0}{0}", copyright);
        }
    }
