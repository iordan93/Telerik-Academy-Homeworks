using System;
    class SwitchIntDoubleOrString
    {
        static void Main()
        {
            Console.WriteLine("What would you like to input?");
            Console.Write("Type \"1\" for int, \"2\" for double or \"3\" for string: ");
            byte n = byte.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.Write("Write the integer: ");
                    int intNumber = int.Parse(Console.ReadLine());
                    intNumber++;
                    Console.WriteLine(intNumber);
                    break;
                case 2:
                    Console.Write("Write the real number: ");
                    double doubleNumber = double.Parse(Console.ReadLine());
                    doubleNumber++;
                    Console.WriteLine(doubleNumber);
                    break;
                case 3:
                    Console.WriteLine("Enter the text:");
                    string text = Console.ReadLine();
                    Console.WriteLine(text + "*");
                    break;
                default:
                    Console.WriteLine("You entered an invalid number.");
                    break;
            }
        }
    }
