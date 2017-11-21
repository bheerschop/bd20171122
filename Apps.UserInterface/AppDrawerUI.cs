//AppDrawerUI.cs
using Apps.AppDrawerNS.BusinessLogic;
using System;

namespace Apps.AppDrawerNS.UserInterface
{
    /// <summary>
    /// The User Interface Component of the AppDrawer App
    /// </summary>
    internal class AppDrawerUI
    {
        private AppDrawerBL logic;
        /// <summary>
        /// Initializes the User Interface component
        /// </summary>
        /// <param name="logic">The Business Logic component of the AppDrawer App</param>
        internal AppDrawerUI(AppDrawerBL logic)
        {
            this.logic = logic;
        }
        /// <summary>
        /// The Main screen of the AppDrawer APp
        /// </summary>
        internal void MainScreen()
        {
            string operation = "";
            while (operation.ToUpper() != "X")
            {
                Console.Clear();
                for (int i = 0; i < logic.AppsCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {logic[i].Name}");
                }
                Console.WriteLine("A. Turn WiFi On");
                Console.WriteLine("B. Turn WiFi Off");
                Console.WriteLine("X. Exit");
                Console.Write("Please Type Your Choice And Press Enter: ");
                operation = Console.ReadLine();
                if (operation.ToUpper() == "A")
                    logic.NetworkService.TurnOnWiFi();
                else if(operation.ToUpper()=="B")
                    logic.NetworkService.TurnOffWiFi();
                else if (operation.ToUpper() != "X")
                {
                    int index = 0;

                    try
                    {
                        index = int.Parse(operation);
                        if (index >= 1 && index <= logic.AppsCount)
                        {
                            logic[index - 1].Start();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry, I do not understand, please try again");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
