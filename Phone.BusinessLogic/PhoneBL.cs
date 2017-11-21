//PhoneBL.cs
using Apps.AddressBookNS;
using Apps.AppDrawerNS;
using Apps.CalculatorNS;
using Phone.Services;

namespace PhoneNS.BusinessLogic
{
    /// <summary>
    /// The logic behind a Phone
    /// </summary>
    internal class PhoneBL
    {
        internal NetworkService NetworkService { get; private set; }
        /// <summary>
        /// The Brand of the Phone
        /// </summary>
        internal string Brand { get; set; }
        /// <summary>
        /// The Phone Model
        /// </summary>
        internal string Model { get; set; }

        /// <summary>
        /// The App responsible to manage all the other Apps of this Phone
        /// </summary>
        internal AppDrawer AppDrawer { get; }

        /// <summary>
        /// Initializes the logic. It creates an AppDrawer, an AddressBook and a Calculator
        /// </summary>
        internal PhoneBL()
        {
            NetworkService = new NetworkService();
            AppDrawer = new AppDrawer(NetworkService);
            AppDrawer.AddApp(new AddressBook());
            AppDrawer.AddApp(new Calculator());
        }
    }
}
