using System;
class PrintDecHexPercentageAndScientific
{
    static void Main()
    {
        Console.WriteLine("This program will read a number and then display it in four ways:");
        Console.WriteLine("as a decimal number, hexadecimal number, percentage, and in scientific notation.");
        
        // Input
        Console.Write("Enter a number: ");
        long number = long.Parse(Console.ReadLine());

        // {0,15} - align right in 15 symbols
        // D - decimal dumber, X - hexadecimal number, P - percentage, E - scientific (exponential) notation
        Console.WriteLine("Decimal: {0,15:D}", number);
        Console.WriteLine("Hexadecimal: {0,15:X}", number);
        Console.WriteLine("Percentage: {0,15:P}", number);
        Console.WriteLine("Scientific notation: {0,15:E}", number);
    }
}
