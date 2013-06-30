namespace _3.FindSetOfWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using rmandvikar.Trie;

    public class FindSetOfWords
    {
        public static void Main()
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var words = GetWords();
            timer.Stop();
            Console.WriteLine("Adding the words to a collection: {0}", timer.Elapsed);

            var trie = TrieFactory.GetTrie();
            timer.Start();

            foreach (var word in words)
            {
                trie.AddWord(word);
            }
            timer.Stop();
            Console.WriteLine("Adding words to the trie: " + timer.Elapsed);
            
            timer.Restart();
            Console.WriteLine("Number of occurrences of \"the\": {0}", trie.WordCount("the"));
            Console.WriteLine("Counting the word \"the\": {0}", timer.Elapsed);

        }
        static ICollection<string> GetWords()
        {
            StreamReader input = new StreamReader("../../input.txt");
            using (input)
            {
                List<string> words = new List<string>();

                string line = input.ReadLine();
                while (line != null)
                {
                    string[] currentWords = Regex.Matches(line, @"[a-zA-Z]+").Cast<Match>().Select(m => m.Value).ToArray();
                    words.AddRange(currentWords.Select(word => word.ToLower()));

                    line = input.ReadLine();
                }

                return words;
            }
        }
    }
}
