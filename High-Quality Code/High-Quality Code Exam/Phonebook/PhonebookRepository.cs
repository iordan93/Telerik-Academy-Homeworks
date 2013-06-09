namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookRepository : IPhonebookRepository
    {
        private List<PhonebookEntry> entries = new List<PhonebookEntry>();

        public List<PhonebookEntry> Entries
        {
            get
            {
                return this.entries;
            }

            private set
            {
                this.entries = value;
            }
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var existingEntries =
                from entry in this.Entries
                where entry.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select entry;

            bool isNewEntry = false;
            if (existingEntries.Count() == 0)
            {
                SortedSet<string> newPhoneNumbers = new SortedSet<string>();
                foreach (var number in phoneNumbers)
                {
                    newPhoneNumbers.Add(number);
                }

                PhonebookEntry entry = new PhonebookEntry(name, newPhoneNumbers);
                this.Entries.Add(entry);
                isNewEntry = true;
            }
            else if (existingEntries.Count() == 1)
            {
                PhonebookEntry entryToMerge = existingEntries.First();

                foreach (var number in phoneNumbers)
                {
                    entryToMerge.PhoneNumbers.Add(number);
                }

                isNewEntry = false;
            }
            else
            {
                throw new ArgumentException("Duplicate name in the phonebook found: " + name + ".");
            }

            return isNewEntry;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var oldEntries =
                from entry in this.Entries
                where entry.PhoneNumbers.Contains(oldNumber)
                select entry;

            int changedPhonesCount = 0;
            foreach (var entry in oldEntries)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                entry.PhoneNumbers.Add(newNumber);
                changedPhonesCount++;
            }

            return changedPhonesCount;
        }

        public PhonebookEntry[] ListEntries(int startIndex, int numberOfEntries)
        {
            if (startIndex < 0 || startIndex + numberOfEntries > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.Entries.Sort();

            PhonebookEntry[] entriesToList = new PhonebookEntry[numberOfEntries];

            // Performance bottleneck - cannot be removed without changing the interface
            for (int i = startIndex; i < startIndex + numberOfEntries; i++)
            {
                entriesToList[i - startIndex] = this.Entries[i];
            }

            return entriesToList;
        }
    }
}