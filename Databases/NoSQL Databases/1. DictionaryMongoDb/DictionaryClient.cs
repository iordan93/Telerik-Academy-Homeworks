namespace _1.DictionaryMongoDb
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class DictionaryClient
    {
        public static void Main()
        {
            MongoUrl url = new MongoUrl("mongodb://localhost");
            MongoClient client = new MongoClient(url);
            MongoServer server = client.GetServer();

            MongoDatabase database = server.GetDatabase("dictionary-server");

            // Remove a previous instance of the dictionary collection if needed
            // database.DropCollection("Dictionary");
            MongoCollection<BsonDocument> dictionary = database.GetCollection("Dictionary");
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

        private static void AddDictionaryEntry(MongoCollection dictionary)
        {
            Console.WriteLine("Enter the word and translation, separated by a colon (:):");
            string[] entry = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Two-way translation
            dictionary.Insert<DictionaryEntry>(new DictionaryEntry() { Word = entry[0], Translation = entry[1] });
            dictionary.Insert<DictionaryEntry>(new DictionaryEntry() { Word = entry[1], Translation = entry[0] });

            Console.WriteLine("The entry was inserted successfully.");
        }

        private static void ListEntries(MongoCollection dictionary)
        {
            Console.WriteLine("All words and translations:");
            var entries = dictionary.FindAllAs<DictionaryEntry>();
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.Word + "\t" + entry.Translation);
            }
        }

        private static void FindTranslation(MongoCollection dictionary)
        {
            Console.WriteLine("Enter the word you are looking for:");
            string word = Console.ReadLine();

            var entries = dictionary.AsQueryable<DictionaryEntry>().Where(e => e.Word == word);
            if (entries.Count() == 0)
            {
                Console.WriteLine("The word was not found in the dictionary.");
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry.Word + "\t" + entry.Translation);
            }
        }
    }
}
