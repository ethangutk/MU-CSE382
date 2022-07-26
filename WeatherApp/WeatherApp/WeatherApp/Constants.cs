using WeatherApp.Helpers;

namespace WeatherApp
{
    public static class Constants
    {
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string OpenWeatherMapAPIKey = Secrets.APIKEY;
    }
}
