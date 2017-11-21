//AddressBookBL.cs
using Apps.AddressBookNS.Model;
using Apps.DataLayer;

namespace Apps.AddressBookNS.BusinessLogic
{
    internal class AddressBookBL 
    {
        /// <summary>
        /// Creates an Address Book with room for 100 Contacts
        /// </summary>
        internal AddressBookBL()  
        {
            contacts = new Container<Contact>();
        }

        /// <summary>
        /// The Collection of Contacts stored in the Address Book
        /// </summary>
        private Container<Contact> contacts;

        /// <summary>
        /// The number of contacts currently in the Phone
        /// </summary>
        internal int ContactsCount => contacts.Count;

        /// <summary>
        /// Gets a Contact from the phone
        /// </summary>
        /// <param name="index">The position of the Contact to retrieve</param>
        /// <returns></returns>
        internal Contact this[int index] {
            get {
                return contacts[index];
            }
        }

        /// <summary>
        /// Adds a contact in the correct position. 
        /// Eventually increases the size of the list of another 100 places if necessary.
        /// </summary>
        /// <param name="toAdd">The contact to insert in the list</param>
        internal void AddContact(Contact toAdd) => contacts.Add(toAdd);
        
        /// <summary>
        /// Creates a new Contact and adds it to the address book
        /// </summary>
        /// <param name="name">The Name of the contact to add</param>
        /// <param name="phoneNumber">The phone number of the contact to add</param>
        internal void AddContact(string name, string phoneNumber)
        {
            Contact newContact = new Contact() { Name = name, PhoneNumber = phoneNumber };
            AddContact(newContact);
        }

        /// <summary>
        /// Filters the Contacts of the AddressBook whose Name starts with an A
        /// </summary>
        /// <returns>The Contacts of the AddressBook whose Name starts with an A</returns>
        internal Contact[] FilterByNameStartingWithA()
        {
            return Filter(toCheck => toCheck.Name.ToLower().StartsWith("a"));
        }

        /// <summary>
        /// Filters the Contacts of the AddressBook whose Phone Number starts with a 06
        /// </summary>
        /// <returns>The Contacts of the AddressBook whose Phone Number starts with a 06</returns>
        internal Contact[] FilterByPhoneNumberStartingWith06()
        {
            return Filter(toCheck => toCheck.PhoneNumber.StartsWith("06"));
        }

        /// <summary>
        /// Filters the Contacts of the AddressBook whose Name ends in "son"
        /// </summary>
        /// <returns>The Contacts of the AddressBook whose Name ends in "son"</returns>
        internal Contact[] FilterByNamesEndingInSon()
        {
            return Filter(toCheck => toCheck.Name.ToLower().EndsWith("son"));
        }

        /// <summary>
        /// Filters the Contacts of the AddressBook based on a predicate
        /// </summary>
        /// <returns>The Contacts of the AddressBook whose condition is fulfilled by the predicate</returns>
        internal Contact[] Filter(CheckerInvoker<Contact> checker) {
            return contacts.Filter(checker).ToArray();
        }
    }
}
