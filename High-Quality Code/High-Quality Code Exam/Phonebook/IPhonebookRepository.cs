namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a new entry with the specified name and phone numbers to the phonebook.
        /// </summary>
        /// <param name="name">The name of the phones owner.</param>
        /// <param name="phoneNumbers">Collection of one or more phone numbers for the specified name.</param>
        /// <remarks>Names are case-insensitive. If a duplicate name is added, the two entries are merged.</remarks>
        /// <exception cref="System.ArgumentException">Duplicate name in the phonebook found.</exception>
        /// <returns>Returns true if the phonebook entry is new and false if it is merged with an existing one.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes the specified old phone in all phonebook entries with a new one.
        /// </summary>
        /// <param name="oldPhoneNumber">The phone number to be replaced.</param>
        /// <param name="newPhoneNumber">The phone number to replace all occurrences of the old phone number.</param>
        /// <returns>Returns the number of affected phonebook entries.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Lists the phonebook entries with paging.
        /// </summary>
        /// <param name="startIndex">The zero-based index of the first phonebook entry to list.</param>
        /// <param name="count">The number of phonebook entries to list.</param>
        /// <returns>Returns an array of phonebook entries starting at the specified index and having the specified length.</returns>
        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}
