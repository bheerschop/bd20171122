//Contact.cs
namespace Apps.AddressBookNS.Model
{
    /// <summary>
    /// Represents a Contact in an Address Book
    /// </summary>
    public class Contact
    {
        private string name;

        /// <summary>
        /// The Name of the Contact. It cannot be longer than 20 characters.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length <= 20)
                    name = value;
                else
                    name = value.Substring(0, 20);
            }
        }

        /// <summary>
        /// The Phone Number of the Contact
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
