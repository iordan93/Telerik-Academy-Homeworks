using System;
using System.Text;

class BinaryToHexadecimal
    {
        static string BinToHex(string number)
        {
            StringBuilder result = new StringBuilder();
            
            // If needed, append leading zeroes to make exact groups of four digits
            while (number.Length %4 != 0)
            {
                number = '0' + number;                   
            }

            // For each part of four digits, take the corresponding number and append it to the result
            for (int index = 0; index < number.Length; index+=4)
            {
                switch (number.Substring(index,4))
                {
                    case "0000": result.Append('0'); break;
                    case "0001": result.Append('1'); break;
                    case "0010": result.Append('2'); break;
                    case "0011": result.Append('3'); break;
                    case "0100": result.Append('4'); break;
                    case "0101": result.Append('5'); break;
                    case "0110": result.Append('6'); break;
                    case "0111": result.Append('7'); break;
                    case "1000": result.Append('8'); break;
                    case "1001": result.Append('9'); break;
                    case "1010": result.Append('A'); break;
                    case "1011": result.Append('B'); break;
                    case "1100": result.Append('C'); break;
                    case "1101": result.Append('D'); break;
                    case "1110": result.Append('E'); break;
                    case "1111": result.Append('F'); break;
                    default: break;
                }
            }
            return result.ToString();
        }

        static void Main()
        {
            Console.WriteLine("This program will get an integer in binary numberal system and convert it to hexadecimal numeral system directly.");
            Console.Write("Enter a positive binary number: ");
            string number = Console.ReadLine();

            string result = BinToHex(number);

            Console.WriteLine("{0} in hexadecimal numeral system is 0x{1}.", number, result);
        }
    }