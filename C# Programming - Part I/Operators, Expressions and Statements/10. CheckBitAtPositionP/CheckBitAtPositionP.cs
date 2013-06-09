using System;

    class CheckBitAtPositionP
    {
        static void Main()
        {
            Console.Write("Enter number v: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position p: ");
            int position = int.Parse(Console.ReadLine()); 
            int i = 1;
            int mask = i << position; 
            Console.WriteLine((number & mask) != 0 ? "True" : "False");
        }
    }