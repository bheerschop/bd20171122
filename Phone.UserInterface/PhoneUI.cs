using Phone.Enums;
using PhoneNS.BusinessLogic;
using System;

namespace PhoneNS.UserInterface
{
    /// <summary>
    /// The User interface component of the Phone
    /// </summary>
    internal class PhoneUI
    {
        private PhoneBL logic;
        /// <summary>
        /// Initializes the User Interface
        /// </summary>
        /// <param name="logic">The Business Logic component to talk to</param>
        internal PhoneUI(PhoneBL logic)
        {
            this.logic = logic;
            this.logic.NetworkService.OnlineEvent += onNetworkEvent;
            this.logic.NetworkService.OfflineEvent += onNetworkEvent;
        }

        /// <summary>
        /// Updates the screen with the state of the network connection
        /// </summary>
        private void onNetworkEvent()
        {
            Console.WriteLine(logic.NetworkService.State.GetDescription());
            Console.ReadLine();
        }

        /// <summary>
        /// It starts the AppDrawer to show the list of available Apps 
        /// </summary>
        public void MainScreen() {
            Console.Clear();
            Console.WriteLine($"*****{logic.Brand} {logic.Model}*****");
            logic.AppDrawer.Start();
            Console.WriteLine("Bye.");
        }
    }
}
