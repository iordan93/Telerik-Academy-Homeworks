namespace ValidateHtml
{
    using System;
    using System.Collections.Generic;

    public class ValidateHtml
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine(ValidateLine(Console.ReadLine()));
            }
        }

        private static string ValidateLine(string line)
        {
            string[] tagsInfo = line.Split(new string[] { "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> tagsValidator = new Stack<string>();
            foreach (var tag in tagsInfo)
            {
                if (!tag.StartsWith("/"))
                {
                    tagsValidator.Push(tag);
                }
                else
                {
                    string closingTag = tag.Substring(1);
                    if (closingTag != tagsValidator.Pop())
                    {
                        return "INVALID";
                    }
                }
            }

            if (tagsValidator.Count != 0)
            {
                return "INVALID";
            }

            return "VALID";
        }
    }
}
