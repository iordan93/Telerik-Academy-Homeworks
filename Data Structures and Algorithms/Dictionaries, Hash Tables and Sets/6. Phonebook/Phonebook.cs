namespace _6.Phonebook
{
    using System;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Phonebook
    {
        private static readonly MultiDictionary<string, PhonebookEntry> entriesByName = new MultiDictionary<string, PhonebookEntry>(true);

        private static readonly MultiDictionary<Tuple<string, string>, PhonebookEntry> entriesByNameAndTown = new MultiDictionary<Tuple<string, string>, PhonebookEntry>(true);

        public static void Main()
        {
            StreamReader phonesFile = new StreamReader("../../phones.txt");
            using (phonesFile)
            {
                string line = phonesFile.ReadLine();
                while (line != null)
                {
                    string[] entryParts =
                        line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(argument => argument.Trim())
                            .ToArray();
                    AddPhonebookEntry(entryParts[0], entryParts[1], entryParts[2]);
                    line = phonesFile.ReadLine();
                }
            }

            StreamReader commands = new StreamReader("../../commands.txt");
            using (commands)
            {
                string line = line = commands.ReadLine();
                while (line != null)
                {
                    string[] commandParts =
                        line.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(argument => argument.Trim())
                            .ToArray();

                    ProcessCommand(commandParts);
                    line = commands.ReadLine();
                }
            }
        }

        private static void AddPhonebookEntry(string name, string town, string phone)
        {
            PhonebookEntry entry = new PhonebookEntry(name, town, phone);

            Tuple<string, string> nameAndTown = new Tuple<string, string>(entry.Name, entry.Town);

            entriesByName.Add(name, entry);
            entriesByNameAndTown.Add(nameAndTown, entry);
        }

        private static PhonebookEntry[] FindEntries(string name)
        {
            return entriesByName[name].ToArray();
        }

        private static PhonebookEntry[] FindEntries(string name, string town)
        {
            Tuple<string, string> nameAndTown = new Tuple<string, string>(name, town);

            return entriesByNameAndTown[nameAndTown].ToArray();
        }

        private static void ProcessCommand(string[] commandParts)
        {
            if (commandParts.Length > 2)
            {
                var result = FindEntries(commandParts[1], commandParts[2]);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                var result = FindEntries(commandParts[1]);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}