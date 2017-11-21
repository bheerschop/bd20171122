//WeatherAppBL.cs

using Phone.Services;

namespace Apps.WeatherAppNS.BusinessLogic
{
    /// <summary>
    /// The logic behind the WeatherApp
    /// </summary>
    internal class WeatherAppBL 
    {
        private string weatherForecast;

        internal NetworkService NetworkService { get; set; }

        public WeatherAppBL()
        {
            UpdateWeatherForecast();
        }
        /// <summary>
        /// Returns the Weather Forecast for today and tomorrow
        /// </summary>
        /// <returns>The Weather Forecast for Today and Tomorrow</returns>
        internal string WeatherForecast() {
            return weatherForecast;
        }

        /// <summary>
        /// Retrieves new content from the network
        /// </summary>
        internal void UpdateWeatherForecast()
        {
            string downloadedContent = NetworkService?.Download("http://theweatherservice.com");
            weatherForecast = $"Sunny and warm today and tomorrow! ({downloadedContent})";
        }
    }
}
