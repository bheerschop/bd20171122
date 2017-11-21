//WeatherAppUI.cs
using Apps.WeatherAppNS.BusinessLogic;
using System;

namespace Apps.WeatherAppNS.UserInterface
{
    /// <summary>
    /// The User Interface component of the Weather App
    /// </summary>
    internal class WeatherAppUI {
        private string name;
        private WeatherAppBL logic;
        /// <summary>
        /// Initializes the User Interface component of the Weather App
        /// </summary>
        /// <param name="name">The name of the App to show on the screen</param>
        /// <param name="logic">The business logic component of the Weather App</param>
        public WeatherAppUI(string name, WeatherAppBL logic)
        {
            this.name = name;
            this.logic = logic;
        }
        /// <summary>
        /// The Main Screen of the Weather App
        /// </summary>
        internal void MainScreen() {
            Console.Clear();
            Console.WriteLine($"*****{name}*****");
            Console.WriteLine(logic.WeatherForecast());
            Console.ReadLine();
        } 
    }
}
