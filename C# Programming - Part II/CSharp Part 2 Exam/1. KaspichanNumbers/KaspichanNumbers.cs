using System;
using System.Numerics;
using System.Text;

class KaspichanNumbers
{
    static string ConvertFromDecimal(BigInteger number, int baseTo=256)
    {
        // Get the remnants in reverse order
        string result = string.Empty;
        while (number != 0)
        {
            result = GetSymbol(number % baseTo) + result;
            number /= baseTo;
        }
        return result;
    }

    static string GetSymbol(BigInteger n)
    {
        char[] secondElements = new char[26];
        for (int i = 0; i < 26; i++)
        {
            secondElements[i] = (char)(i + 'A');
        }
        char[] firstElements = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
        
        string[] elements = new string[260];
        for (int i = 0; i < 26; i++)
        {
            elements[i] = secondElements[i].ToString();
        }
        for (int i = 1; i < 10; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                elements[j+26*i] = firstElements[i-1].ToString() + secondElements[j].ToString();
            }
        }
        for (int i = 0; i < 256; i++)
        {
            if (n == i)
            {
                return elements[i];
            }
        }
        return "";
    }

    static void Main()
    {
        //string input = Console.ReadLine();
        BigInteger parsed = BigInteger.Parse(Console.ReadLine());
        if (parsed == 0)
        {
            Console.WriteLine("A");
        }
        else
        {
            Console.WriteLine(ConvertFromDecimal(parsed));
        }
    }
}
