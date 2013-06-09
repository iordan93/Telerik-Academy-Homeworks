using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter number i: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Enter position b: ");
            int b = int.Parse(Console.ReadLine());
            int maskBase = 1;
            int mask = maskBase << b;
            int iAndMask = i & mask;
            if (iAndMask != 0)
            {
                Console.WriteLine(1); 
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }