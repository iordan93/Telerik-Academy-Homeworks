using System;
using System.Text;

public static class StringBuilderSubstring
{
    // Substring has two overloads for the Substring method
    // The first overload takes one parameter and returns everything to the end of the string
    public static string Substring(this StringBuilder sb, int startIndex)
    {
        if (startIndex < sb.Length)
        {
            // Append each character from the given index to the end
            StringBuilder result = new StringBuilder();
            for (int index = startIndex; index < sb.Length; index++)
            {
                result.Append(sb[index]);
            }
            return result.ToString();
        }
        // If the starting index is not within the string, throw an exception 
        else throw new ArgumentOutOfRangeException("startIndex",
            "The starting index of the substring must be lower than the length of the StringBuilder");
    }

    // The second overload takes two parameters and returns a string starting at a given index, and having the specified length
    public static string Substring(this StringBuilder sb, int startIndex, int length)
    {
        if (startIndex < sb.Length)
        {
            StringBuilder result = new StringBuilder();
            // Append each character from the given index until reaching the specified length
            for (int index = startIndex; index < startIndex + length; index++)
            {
                result.Append(sb[index]);
            }
            return result.ToString();
        }
        // If the starting index is not within the string, throw an exception 
        else throw new ArgumentOutOfRangeException("startIndex",
            "The starting index of the substring must be lower than the length of the StringBuilder");
    }
}
