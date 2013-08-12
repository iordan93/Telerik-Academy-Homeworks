namespace _2.DictionaryRedis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack.Redis;

    public class DictionaryClient
    {
        public static void Main()
        {
            RedisClient client = new RedisClient("localhost", 6379);
            IRedisHash dictionary = client.Hashes["Dictionary"];

            // Remove a previous instance of the dictionary collection if needed            
            // dictionary.Clear();

            while (true)
            {
                Console.WriteLine("Press a key to use one of the following options:");
                Console.WriteLine("1. Add a dictionary entry");
                Console.WriteLine("2. List all entries");
                Console.WriteLine("3. Find the translation of a given word");
                Console.WriteLine("0. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("Thank you for using the dictionary.");
                        return;
                    case "1":
                        AddDictionaryEntry(dictionary);
                        break;
                    case "2":
                        ListEntries(dictionary);
                        break;
                    case "3":
                        FindTranslation(dictionary);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AddDictionaryEntry(IRedisHash dictionary)
        {
            Console.WriteLine("Enter the word and translation, separated by a colon (:):");
            string[] entry = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Two-way translation
            dictionary.AddIfNotExists(new KeyValuePair<string, string>(entry[0], entry[1]));
            dictionary.AddIfNotExists(new KeyValuePair<string, string>(entry[1], entry[0]));

            Console.WriteLine("The entry was inserted successfully.");
        }

        private static void ListEntries(IRedisHash dictionary)
        {
            Console.WriteLine("All words and translations:");
            foreach (var entry in dictionary)
            {
                Console.WriteLine(entry.Key + "\t" + entry.Value);
            }
        }

        private static void FindTranslation(IRedisHash dictionary)
        {
            Console.WriteLine("Enter the word you are looking for:");
            string word = Console.ReadLine();

            var entries = dictionary.Where(e => e.Key == word);
            if (entries.Count() == 0)
            {
                Console.WriteLine("The word was not found in the dictionary.");
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry.Key + "\t" + entry.Value);
            }
        }
    }
}
