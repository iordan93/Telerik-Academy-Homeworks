using System;
class PrintSumOfNumbers
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        int n = int.Parse(Console.ReadLine());
        int number = 0;
        int sum = 0;
        Console.WriteLine("Now enter {0} more numbers:", n);
        for (int i = 1; i <= n; i++)
        {
            number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("The sum is: {0}", sum);
    }
}
