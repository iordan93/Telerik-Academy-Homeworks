using System;
using System.Text;

class EncodeAndDecodeString
{
    // To change the cipher, edit the code directly. If the program offers the option to change the cipher, it will not be protected
    private static string cipher = "This is my cipher phrase!";

    static string Encode(string toEncode)
    {
        // Take each symbol and XOR it with the corresponding symbol of the cypher. If the index of the string to encode is longer than the cipher,
        // take the remnant of its division with the cipher's length (i.e. when the end of the cipher is ended, start at the beginning again)
        StringBuilder encoded = new StringBuilder(toEncode.Length);
        for (int i = 0; i < toEncode.Length; i++)
        {
            int encodeAlgorithm = toEncode[i] ^ cipher[i % cipher.Length];
            encoded.Append((char)encodeAlgorithm);
        }
        return encoded.ToString();
    }

    static string Decode(string toDecode)
    {
        // The decoding algorithm is the same as the encoding algorithm because
        // (toEncode XOR cipher) XOR cipher = toEncode
        StringBuilder decoded = new StringBuilder(toDecode.Length);
        for (int i = 0; i < toDecode.Length; i++)
        {
            int decodeAlgorithm = toDecode[i] ^ cipher[i % cipher.Length];
            decoded.Append((char)decodeAlgorithm);
        }
        return decoded.ToString();
    }

    static void Main()
    {
        // Input
        Console.WriteLine("This program will encode and decode a string using an encoding / decoding algorithm.");
        Console.WriteLine("Enter the string to be encoded: ");
        string input = Console.ReadLine();

        string encoded = Encode(input);
        string decoded = Decode(encoded);

        // Output
        Console.WriteLine("The encoded string is: ");
        Console.WriteLine(encoded);
        Console.WriteLine("The decoded string is: ");
        Console.WriteLine(decoded);
    }
}
