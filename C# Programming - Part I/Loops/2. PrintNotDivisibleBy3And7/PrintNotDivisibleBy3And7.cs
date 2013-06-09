using System;
class PrintNotDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Enter how many numbers you would like to display: ");
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            if ((i % 3 == 0) && (i % 7 == 0))
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}