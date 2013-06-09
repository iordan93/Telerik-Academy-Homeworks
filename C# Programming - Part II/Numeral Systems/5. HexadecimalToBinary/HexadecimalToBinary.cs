using System;
class HexadecimalToBinary
{
    static string HexToBin(string number)
    {
        // For each symbol, take its corresponding set of four binary numbers
        string result = String.Empty;
        for (int index = 0; index < number.Length; index++)
        {
            switch (number[index])
            {
                case '0': result += "0000"; break;
                case '1': result += "0001"; break;
                case '2': result += "0010"; break;
                case '3': result += "0011"; break;
                case '4': result += "0100"; break;
                case '5': result += "0101"; break;
                case '6': result += "0110"; break;
                case '7': result += "0111"; break;
                case '8': result += "1000"; break;
                case '9': result += "1001"; break;
                case 'A': result += "1010"; break;
                case 'B': result += "1011"; break;
                case 'C': result += "1100"; break;
                case 'D': result += "1101"; break;
                case 'E': result += "1110"; break;
                case 'F': result += "1111"; break;
                default: break;
            }
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("This program will get an integer in hexadecimal numberal system and convert it to binary numeral system directly.");
        Console.Write("Enter a positive hexadecimal number: ");
        string number = Console.ReadLine();

        string result = HexToBin(number);

        Console.WriteLine("{0} in binary numeral system is {1}.", number, result);
    }
}
