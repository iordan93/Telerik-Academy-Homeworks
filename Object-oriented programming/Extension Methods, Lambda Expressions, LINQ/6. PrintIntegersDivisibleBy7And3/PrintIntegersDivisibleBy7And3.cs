using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.PrintIntegersDivisibleBy7And3
{
    class PrintIntegersDivisibleBy7And3
    {
        static void Main()
        {
            Random random = new Random();
            // Create some integers between 0 and 2000
            int[] numbers = new int[50];
            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(0, 2001);
            }
            
            // The program can be optimized to look for % 21 but this way makes is easier to change
            // If the problem should be interpreted as "divisible by 7 OR 3", change '&&' to '||'

            // With Lambda expressions
            var divisibleNumbers = numbers.Where(x => (x % 7 == 0 && x % 3 == 0));
            PrintNumbers(divisibleNumbers);

            Console.WriteLine(new string('-',20));

            // With LINQ
            var divisibleNumbersLINQ =
                from number in numbers
                where number % 3 == 0 && number % 7 == 0
                select number;
            PrintNumbers(divisibleNumbers);

        }
  
        private static void PrintNumbers(IEnumerable<int> divisibleNumbers)
        {
            Console.WriteLine("Numbers divisible by 3 and 7:");
            foreach (var number in divisibleNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
