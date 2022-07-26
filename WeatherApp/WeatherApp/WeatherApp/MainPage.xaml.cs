using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        private async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
				string uriRequest = GenerateRequestUri(Constants.OpenWeatherMapEndpoint);
				WeatherData weatherData = await _restService.GetWeatherData(uriRequest);
                BindingContext = weatherData;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
