//WeatherApp.cs
using Apps.Core;
using Apps.WeatherAppNS.BusinessLogic;
using Apps.WeatherAppNS.UserInterface;
using Phone.Services;

namespace Apps.WeatherAppNS
{
    /// <summary>
    /// A Weather App
    /// </summary>
    public class WeatherApp : App, INetworkClient
    {
        private WeatherAppBL logic;
        private WeatherAppUI ui;
        
        /// <summary>
        /// Initializes the app with a name of "Weather App"
        /// </summary>
        public WeatherApp() : base("Weather App")
        {
            logic = new WeatherAppBL();
            ui = new WeatherAppUI(Name, logic);
        }

        public void ConnectToNetworkService(NetworkService networkService)
        {
            logic.NetworkService = networkService;
            logic.NetworkService.OnlineEvent += logic.UpdateWeatherForecast;
        }

        /// <summary>
        /// It starts the App, showint the Main Screen
        /// </summary>
        public override void Start()
        {
            ui.MainScreen();
        }
    }
}