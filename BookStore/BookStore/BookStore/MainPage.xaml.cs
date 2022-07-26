using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		RestService _restService;
		public MainPage() {
			InitializeComponent();
			_restService = new RestService();
		}
        private async void OnClicked(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(topic.Text)) {
                string uriRequest = GenerateRequestUri(Constants.Endpoint);
                BookData bookData = await _restService.GetWeatherData(uriRequest);
                items.ItemsSource = bookData.books;
            }
        }

        string GenerateRequestUri(string endpoint) {
            string requestUri = endpoint;
            requestUri += $"/search/{topic.Text}";
            return requestUri;
        }
    }

}
