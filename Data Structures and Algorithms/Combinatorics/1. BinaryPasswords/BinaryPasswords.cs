using System;
using System.Linq;

public class BinaryPasswords
{
    public static void Main()
    {
        string line = Console.ReadLine();
        int power = line.ToCharArray().Count(x => x == '*');
        long result = (long)Math.Pow(2, power);
        Console.WriteLine(result);
    }
}