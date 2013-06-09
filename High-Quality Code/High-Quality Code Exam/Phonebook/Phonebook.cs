namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Phonebook
    {
        private const string DefaultCode = "+359";
        private static readonly IPhonebookRepository repository = new PhonebookRepository();

        // TODO: Remove unnecessary comments
        private static readonly StringBuilder output = new StringBuilder();

        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End" || input == null)
                {
                    // TODO: Error reading from the console??? 
                    break;
                }

                int commandEndBoundary = input.IndexOf('(');

                // TODO: Only one exception?
                if (commandEndBoundary == -1)
                {
                    throw new FormatException("The command arguments do not start with an opening bracket.");
                }

                if (!input.EndsWith(")"))
                {
                    throw new FormatException("The command arguments do not end with a closing bracket.");
                }

                string commandName = input.Substring(0, commandEndBoundary);

                string[] commandArguments = GetCommandArguments(input, commandEndBoundary);

                ParseAndExecuteCommand(commandName, commandArguments);

                Console.Write(output);
            }
        }

        private static string[] GetCommandArguments(string input, int commandEndBoundary)
        {
            int argumentsStart = commandEndBoundary + 1;
            int argumentsEnd = input.Length - commandEndBoundary - 2;

            string argumentsAsString = input.Substring(argumentsStart, argumentsEnd);
            string[] commandArguments = argumentsAsString.Split(',');

            for (int argumentIndex = 0; argumentIndex < commandArguments.Length; argumentIndex++)
            {
                commandArguments[argumentIndex] = commandArguments[argumentIndex].Trim();
            }

            return commandArguments;
        }

        private static void ParseAndExecuteCommand(string commandName, string[] commandArguments)
        {
            if (commandName == "AddPhone" && commandArguments.Length >= 2)
            {
                ExecuteCommand(CommandType.AddPhone, commandArguments);
            }
            else if (commandName == "ChangePhone" && commandArguments.Length == 2)
            {
                ExecuteCommand(CommandType.ChangePhone, commandArguments);
            }
            else if (commandName == "List" && commandArguments.Length == 2)
            {
                ExecuteCommand(CommandType.List, commandArguments);
            }
            else
            {
                throw new ArgumentException("The command name \"" + commandName + "\" is invalid.");
            }
        }

        private static void ExecuteCommand(CommandType commandType, string[] commandArguments)
        {
            if (commandType == CommandType.AddPhone)
            {
                string name = commandArguments[0];

                // Performance bottleneck: String array conversion to list
                string[] phoneNumbers = commandArguments.Skip(1).ToArray();

                for (int i = 0; i < phoneNumbers.Length; i++)
                {
                    phoneNumbers[i] = ConvertPhoneNumberToCanonicalForm(phoneNumbers[i]);
                }

                bool isNewEntry = repository.AddPhone(name, phoneNumbers);
                if (isNewEntry)
                {
                    Print("Phone entry created");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (commandType == CommandType.ChangePhone)
            {
                string oldPhone = ConvertPhoneNumberToCanonicalForm(commandArguments[0]);
                string newPhone = ConvertPhoneNumberToCanonicalForm(commandArguments[1]);
                int changedNumbers = repository.ChangePhone(oldPhone, newPhone);

                Print(changedNumbers + " numbers changed");
            }
            else if (commandType == CommandType.List)
            {
                try
                {
                    IEnumerable<PhonebookEntry> entries = repository.ListEntries(int.Parse(commandArguments[0]), int.Parse(commandArguments[1]));
                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
            else
            {
                throw new InvalidOperationException("The command type \"" + commandType + "\" is invalid.");
            }
        }

        private static string ConvertPhoneNumberToCanonicalForm(string phoneNumber)
        {
            // Performance bottleneck - multiple appending of the same things
            StringBuilder convertedNumber = new StringBuilder();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    convertedNumber.Append(ch);
                }
            }

            // TODO: This should be done at once
            if (convertedNumber.Length >= 2 && convertedNumber[0] == '0' && convertedNumber[1] == '0')
            {
                convertedNumber.Remove(0, 1);
                convertedNumber[0] = '+';
            }

            while (convertedNumber.Length > 0 && convertedNumber[0] == '0')
            {
                convertedNumber.Remove(0, 1);
            }

            if (convertedNumber.Length > 0 && convertedNumber[0] != '+')
            {
                convertedNumber.Insert(0, DefaultCode);
            }

            return convertedNumber.ToString();
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }
}
