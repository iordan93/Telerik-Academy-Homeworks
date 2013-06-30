namespace _1.MessagesInABottle
{
    using System;
    using System.Collections.Generic;

    public class MessagesInABottle
    {
        private static List<string> decoded = new List<string>();

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            string message = Console.ReadLine();
            string cipherInfo = Console.ReadLine();

            Dictionary<char, string> cipher = new Dictionary<char, string>();
            List<char> chars = new List<char>();
            List<string> values = new List<string>();
            string currentValue = string.Empty;
            for (int i = 0; i < cipherInfo.Length; i++)
            {
                if (char.IsLetter(cipherInfo[i]))
                {
                    chars.Add(cipherInfo[i]);
                    if (currentValue != string.Empty)
                    {
                        values.Add(currentValue);
                        currentValue = string.Empty;
                    }
                }
                else
                {
                    currentValue = currentValue.Insert(currentValue.Length, cipherInfo[i].ToString());
                }
            }

            values.Add(currentValue);

            for (int i = 0; i < chars.Count; i++)
            {
                cipher[chars[i]] = values[i];
            }

            DecodeMessage(message, cipher, string.Empty);

            Console.WriteLine(decoded.Count);
            
            if (decoded.Count > 0)
            {
                decoded.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, decoded));
            }
        }

        private static void DecodeMessage(string message, Dictionary<char, string> cipher, string alreadyDecoded)
        {
            if (message.Length == 0)
            {
                decoded.Add(alreadyDecoded);
            }
            else
            {
                foreach (var codePair in cipher)
                {
                    if (message.StartsWith(codePair.Value))
                    {
                        DecodeMessage(message.Substring(codePair.Value.Length), cipher, alreadyDecoded + codePair.Key.ToString());
                    }
                }
            }
        }
    }
}
