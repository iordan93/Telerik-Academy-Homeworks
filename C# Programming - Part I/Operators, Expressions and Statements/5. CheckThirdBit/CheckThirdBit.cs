using System;

    class CheckThirdBit
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int mask = 1 << 3;
            int numberAndMask = number & mask;
            int bit = numberAndMask >> 3;
            Console.WriteLine("The bit at position 3 is {0}", bit);
        }
    }
