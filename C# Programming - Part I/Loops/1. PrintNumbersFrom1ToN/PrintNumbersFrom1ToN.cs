using System;
class PrintNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Enter how many numbers you would like to display: ");
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
}