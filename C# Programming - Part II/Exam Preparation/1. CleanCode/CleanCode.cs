using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text;

class CleanCode
{
    static void Main()
    {
        StringBuilder builder = new StringBuilder();
        int N = int.Parse(Console.ReadLine());

        bool isInMultiLineComment = false;
        bool isInApostrophe = false;
        bool isInString = false;

        for (int index = 1; index <= N; index++)
        {
            string line = Console.ReadLine();

            // This problem is best solved using an automaton (the program goes into different stages while running)
            for (int i = 0; i < line.Length; i++)
            {
                // Includes string and verbatim (@"") mode
                if (isInString)
                {
                    // If there is an apostrophe within a string, print it in order not to get in Apostrophe mode
                    if ((line[i] == '\\') && (i + 1 < line.Length) && (line[i + 1] == '\''))
                    {
                        builder.Append("\\\'");
                        i++;
                        continue;
                    }
                    if ((line[i] == '\"') && (!isInApostrophe))
                    {
                        isInString = false;
                        builder.Append('\"');
                        continue;
                    }
                    if ((line[i] == '\'') && (isInApostrophe))
                    {
                        isInString = false;
                        isInApostrophe = false;
                        builder.Append('\'');
                        continue;
                    }
                    builder.Append(line[i]);
                    continue;
                }

                // If we are not in a multiline comment and we get into /*, switch into Multiline comment mode
                if ((!isInMultiLineComment) && (i + 1 < line.Length) && (line[i] == '/') && (line[i + 1] == '*'))
                {
                    isInMultiLineComment = true;
                    i++;
                    continue;
                }
                // Get out of Multiline comment mode after */
                if ((isInMultiLineComment) && (i + 1 < line.Length) && (line[i] == '*') && (line[i + 1] == '/'))
                {
                    isInMultiLineComment = false;
                    i++;
                    continue;
                }
                if (isInMultiLineComment)
                {
                    continue;
                }

                // If there is a single line comment, skip everything to the end of the line
                // except "///" which denotes inline documentation and should be included in the code
                if ((line[i] == '/') && (i + 1 < line.Length) && (line[i + 1] == '/'))
                {
                    if ((i + 2 < line.Length) && (line[i + 2] == '/'))
                    {
                        builder.Append("///");
                        i += 2;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (line[i] == '\"')
                {
                    isInString = true;
                }

                if (line[i] == '\'')
                {
                    isInString = true;
                    isInApostrophe = true;
                }

                builder.Append(line[i]);
            }
            // If we are not in a multiline comment, append the end-of-line symbol and proceed reading the new line
            if (!isInMultiLineComment)
            {
                builder.AppendLine();
            }
        }

        StringReader reader = new StringReader(builder.ToString());
        string lineToPrint = null;
        while ((lineToPrint = reader.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(lineToPrint))
            {
                Console.WriteLine(lineToPrint);
            }
        }
    }
}