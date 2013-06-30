namespace _6.Phonebook
{
    using System;

    public class PhonebookEntry
    {
        public PhonebookEntry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name { get; private set; }

        public string Town { get; private set; }
        
        public string Phone { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2}", this.Name, this.Town, this.Phone);
        }
    }
}
