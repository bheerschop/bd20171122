//AddressBook.cs
using Apps.AddressBookNS.BusinessLogic;
using Apps.AddressBookNS.Model;
using System;

namespace Apps.AddressBookNS.UserInterface
{
    /// <summary>
    /// The User Interface component of the Address Book App
    /// </summary>
    internal class AddressBookUI
    {
        private AddressBookBL logic;
        private string name;
        /// <summary>
        /// Initializes the User Interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logic"></param>
        internal AddressBookUI(string name, AddressBookBL logic)  
        {
            this.name = name;
            this.logic = logic;
        }

        /// <summary>
        /// The Main Screen of the Address Book UI
        /// </summary>
        internal void MainScreen()
        {
            string operation = "";
            while (operation.ToUpper() != "X")
            {
                Console.Clear();
                Console.WriteLine($"*****{name}*****");
                Console.WriteLine("1. Add a Contact");
                Console.WriteLine("2. List All Contacts");
                Console.WriteLine("3. Get a Contact By Position");
                Console.WriteLine("4. Filter Contacts Starting with A");
                Console.WriteLine("5. Filter Contacts Ending in son");
                Console.WriteLine("6. Filter Contacts on a mobile phone");
                Console.WriteLine("7. Filter Contacts By Name containing...");
                Console.WriteLine("8. Filter Contacts By Phone Number containing...");
                Console.WriteLine("X. Exit");
                Console.Write("Please Type Your Choice And Press Enter: ");
                operation = Console.ReadLine();
                int index;

                if (int.TryParse(operation, out index) && (index >=1 && index <=8))
                {
                    switch (operation)
                    {
                        case "1":
                            Console.Write("Please write the Contact Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Please write the Phone Number: ");
                            string phoneNumber = Console.ReadLine();
                            logic.AddContact(name, phoneNumber);
                            Console.WriteLine("Contact Added.");
                            break;
                        case "2":
                            for (int i = 0; i < logic.ContactsCount; i++)
                            {
                                Contact item = logic[i];
                                Console.WriteLine($"Contact {i}: {item.Name} {item.PhoneNumber}");
                            }
                            break;
                        case "3":
                            bool ok = false;
                            int position = 0;
                            while (!ok)
                            {
                                Console.Write("Please insert the position: ");
                                string userInput = Console.ReadLine();
                                try
                                {
                                    position = int.Parse(userInput);
                                    ok = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Sorry, I do not understand, please try again");
                                    Console.ReadLine();
                                }
                            }

                            Contact contact = logic[position];
                            Console.WriteLine($"Contact {position}: {contact?.Name} {contact?.PhoneNumber}");                            
                            break;
                        case "4":
                            Contact[] contacts = logic.FilterByNameStartingWithA();
                            printContacts(contacts);
                            break;
                        case "5":
                            contacts = logic.FilterByNamesEndingInSon();
                            printContacts(contacts);
                            break;
                        case "6":
                            contacts = logic.FilterByPhoneNumberStartingWith06();
                            printContacts(contacts);
                            break;
                        case "7":
                            Console.Write("Please insert the value to filter: ");
                            string filterValue = Console.ReadLine();
                            contacts = logic.Filter(item => item.Name.ToLower().Contains(filterValue));
                            printContacts(contacts);
                            break;
                        case "8":
                            Console.Write("Please insert the value to filter: ");
                            filterValue = Console.ReadLine();
                            contacts = logic.Filter(item => item.PhoneNumber.ToLower().Contains(filterValue));
                            printContacts(contacts);
                            break;
                    }
                    Console.ReadLine();
                }
                else if (operation.ToUpper() != "X")
                {
                    Console.WriteLine("Sorry, I do not understand, please try again");
                    Console.ReadLine();
                }
            }
        }

        private void printContacts(Contact[] contacts)
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                Contact item = contacts[i];
                Console.WriteLine($"Contact {i}: {item.Name} {item.PhoneNumber}");
            }
        }
    }
}
