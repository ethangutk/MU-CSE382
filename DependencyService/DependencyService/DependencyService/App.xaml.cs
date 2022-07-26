using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DependencyService {
	public partial class App : Application {
		public App() {
			IPlatformSpecificCode service = Xamarin.Forms.DependencyService.Get<IPlatformSpecificCode>();
			MainPage = new MainPage(service.Platform());
		}
	}
}
