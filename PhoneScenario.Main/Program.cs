using Apps.AddressBookNS;
using Apps.AddressBookNS.Model;
using Apps.WeatherAppNS;
using PhoneNS;
using System;

namespace PhoneScenario.Main
{
    class Program
    {
        /// <summary>
        /// The starting point of our application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //initialize the old phone
            Phone phone = new Phone() { Brand = "Apple", Model = "iPhone5" };
            AddressBook agenda = phone.AppDrawer.FindApp<AddressBook>();

            //add some contacts with some details
            agenda.AddContact(new Contact() { Name = "Alice Anderson", PhoneNumber = "0612345678" });
            agenda.AddContact(new Contact() { Name = "Bob Builders", PhoneNumber = "+39 347 2839654" });
            agenda.AddContact(new Contact() { Name = "Candice Clarkson", PhoneNumber = "065707483" });
            agenda.AddContact(new Contact() { Name = "David Danielson", PhoneNumber = "060485289" });
            agenda.AddContact(new Contact() { Name = "Daenerys Stormborn of House Targaryen, the Unburnt, Mother of Dragons, khaleesi to Drogo's riders, and queen of the Seven Kingdoms of Westeros", PhoneNumber = "063058673" });

            //we add a new App and the Phone still works
            phone.AppDrawer.AddApp(new WeatherApp());

            phone.Start();

            Console.ReadLine();
        }
    }
}
