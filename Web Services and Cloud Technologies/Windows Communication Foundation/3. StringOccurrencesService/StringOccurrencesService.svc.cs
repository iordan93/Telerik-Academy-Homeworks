namespace _3.StringOccurrencesService
{
    using System;

    public class StringOccurrencesService : IStringOccurrencesService
    {
        public long CountOccurrences(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input", "The input must not be null or an empty string.");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern", "The pattern must not be null.");
            }

            long count = 0;
            int index = 0;
            index = input.IndexOf(pattern, index);

            while (index != -1)
            {
                index += pattern.Length;
                count++;

                index = input.IndexOf(pattern, index);
            }

            return count;
        }
    }
}
