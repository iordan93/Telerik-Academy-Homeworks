using System;

    class SumOfNumbers
    {
        static void Main()
        {
            Console.Write("Enter a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter c = ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("a + b + c = {0}", a+b+c);
        }
    }
