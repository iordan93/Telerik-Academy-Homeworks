/// <summary>
/// Common methods for the Telerik Integrated Learning System (TILS)
/// </summary>
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A class that extends the System.String class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts this instance to its respective MD5 checksum
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the MD5 checksum of the input string</returns>
        public static string ToMd5Hash(string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts this instance to its respective boolean value
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the boolean equivalent of the input string</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts this instance to its respective 16-bit signed integer value
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the 16-bit signed integer equivalent of the input string</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts this instance to its respective 32-bit signed integer value
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the 32-bit signed integer equivalent of the input string</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts this instance to its respective 64-bit signed integer value
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the 64-bit signed integer equivalent of the input string</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts this instance to its respective System.DateTime value
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the System.DateTime equivalent of the input string</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of this instance
        /// </summary>
        /// <param name="input">The string whose first letter should be capitalized</param>
        /// <returns>
        /// Returns a copy of this string with capitalized first letter (ex: some sample -> Some sample).
        /// <para>If the string is null or empty, returns the original string</para>
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the substring from this instance between two specified strings
        /// </summary>
        /// <param name="input">The string to be checked</param>
        /// <param name="startString">The starting string</param>
        /// <param name="endString">The ending string</param>
        /// <param name="startFrom">The zero-based index of the input string where the search should begin</param>
        /// <returns>Returns the substring of this instance between the two specified strings, excluding them</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts all Cyrillic letters of this instance to their respective Latin counterparts
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the Latin counterpart of this string</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                // Replace small and capital letters consecutively
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts all Latin letters of this instance to their respective Cyrillic counterparts
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the Cyrillic counterpart of this string</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                // Replace small and capital letters consecutively
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts this instance to valid username (no Cyrillic letters, and no special characters)
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns a copy of this instance resembling a valid username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts this instance to valid Latin file name (no Cyrillic letters, no spaces, and no special characters)
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns a copy of this instance resembling a valid Latin file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring of this instance containing a specified number of characters 
        /// </summary>
        /// <param name="input">The string to be manipulated</param>
        /// <param name="charsCount">The number of characters in the substring</param>
        /// <returns>Returns the first characters of the string.
        /// <para>If the characters are more than the length of this instance, returns the whole instance</para>
        /// </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension of a file name
        /// </summary>
        /// <param name="fileName">The file name represented as System.String</param>
        /// <returns>
        /// Returns the file extension of the given file name.
        /// <para>If the string is null, empty, or there is no file extension, returns an empty string</para>
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts a file extension specified as string to its respective content type
        /// </summary>
        /// <param name="fileExtension">The file extension represented as System.String</param>
        /// <returns>Returns the content type of the input file extension, represented as System.String</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts this instance to array of 8-bit unsigned integers
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Returns the array of 8-bit unsigned integers, representing the input</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
