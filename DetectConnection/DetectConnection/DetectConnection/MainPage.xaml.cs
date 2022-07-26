using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace DetectConnection {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			Connectivity.ConnectivityChanged += OnConnectivityChanged;
		}

		private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e) {
			connectivityChanging.Text = e.NetworkAccess.ToString();
		}

		private void CheckClicked(object sender, EventArgs e) {
			connectivity.Text = Connectivity.NetworkAccess == NetworkAccess.None ?
									"None" : "OK";
		}
	}
}
