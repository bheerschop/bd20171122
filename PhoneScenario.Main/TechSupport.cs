//TechSupport.cs
using Apps.AddressBookNS;
using Apps.AddressBookNS.Model;
using PhoneNS;

namespace PhoneScenario.Main
{
    /// <summary>
    /// The Tech Support. It manages Phones.
    /// </summary>
    public class TechSupport
    {
        /// <summary>
        /// Copies the Contacts from one source Phone to a target Phone
        /// </summary>
        /// <param name="source">The Phone with the source collection of contacts to be copied to the target</param>
        /// <param name="target">The target Phone that will receive the contacts from the source</param>
        public void CopyContacts(Phone source, Phone target) {
            AddressBook sourceAgenda = source.AppDrawer.FindApp<AddressBook>();
            AddressBook targetAgenda = target.AppDrawer.FindApp<AddressBook>();

            for (int i = 0; i < sourceAgenda.ContactsCount; i++)
            {
                Contact oldContact = sourceAgenda[i];
                targetAgenda.AddContact(oldContact.Name, oldContact.PhoneNumber );
            }
        }
    }
}
