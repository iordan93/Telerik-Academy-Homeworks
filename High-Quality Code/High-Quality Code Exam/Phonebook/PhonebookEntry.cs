namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        // TODO: Check class access modifiers
        private string name;
        private SortedSet<string> phoneNumbers;

        public PhonebookEntry(string name, SortedSet<string> phoneNumbers)
        {
            this.Name = name;
            this.PhoneNumbers = phoneNumbers;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public SortedSet<string> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            private set
            {
                this.phoneNumbers = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('[');
            output.Append(this.Name);

            bool isNamePrinted = true;

            foreach (var phoneNumber in this.PhoneNumbers)
            {
                if (isNamePrinted)
                {
                    output.Append(": ");
                    isNamePrinted = false;
                }
                else
                {
                    output.Append(", ");
                }

                output.Append(phoneNumber);
            }

            output.Append(']');

            return output.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            string nameLowercase = this.Name.ToLowerInvariant();
            string otherNameLowercase = other.Name.ToLowerInvariant();

            return nameLowercase.CompareTo(otherNameLowercase);
        }
    }
}
