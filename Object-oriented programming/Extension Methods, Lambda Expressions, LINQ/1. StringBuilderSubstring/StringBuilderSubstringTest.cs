using System;
using System.Text;

class StringBuilderSubstringTest
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("0123456789");
        // Test of the first overloaded method
        Console.WriteLine(sb.Substring(4));

        // Test of the second overloaded method
        Console.WriteLine(sb.Substring(4, 3));
    }
}