//AddressBook.cs

using Apps.AddressBookNS.BusinessLogic;
using Apps.AddressBookNS.Model;
using Apps.AddressBookNS.UserInterface;
using Apps.Core;

namespace Apps.AddressBookNS
{
    /// <summary>
    /// The AddressBook App
    /// </summary>
    public class AddressBook : App
    {
        private AddressBookBL logic;
        private AddressBookUI ui;
        /// <summary>
        /// Initializes the AddressBook App with a Name of "Address Book"
        /// </summary>
        public AddressBook() :base("Address Book") 
        {
            logic = new AddressBookBL();
            ui = new AddressBookUI(this.Name, logic);
        }

        /// <summary>
        /// It shows the Main Screen of the User Interface
        /// </summary>
        public override void Start()
        {
            ui.MainScreen();
        }

        
        /// <summary>
        /// The number of contacts currently in the AddressBook
        /// </summary>
        public int ContactsCount => logic.ContactsCount;

        /// <summary>
        /// Gets a Contact from the Address Book
        /// </summary>
        /// <param name="index">The position of the Contact to retrieve</param>
        /// <returns></returns>
        public Contact this[int index]
        {
            get
            {
                return logic[index];
            }
        }

        /// <summary>
        /// Adds a contact in the correct position. 
        /// Eventually increases the size of the list of another 100 places if necessary.
        /// </summary>
        /// <param name="toAdd">The contact to insert in the list</param>
        public void AddContact(Contact toAdd) => logic.AddContact(toAdd);

        /// <summary>
        /// Creates a new Contact and adds it to the Address Book
        /// </summary>
        /// <param name="name">The Name of the contact to add</param>
        /// <param name="phoneNumber">The phone number of the contact to add</param>
        public void AddContact(string name, string phoneNumber) => logic.AddContact(name, phoneNumber);
    }
}
