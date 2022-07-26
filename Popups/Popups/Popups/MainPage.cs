using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Popups {
	public class MainPage : ContentPage {
		Label label1;
		Button b1;
		Button b2;
		public MainPage() {
			label1 = new Label { Text = "some label information #1" };

			b1 = new Button { Text = "Alert" };
			b1.Clicked += B1_Clicked;

			b2 = new Button { Text = "Action Sheet" };
			b2.Clicked += B2_Clicked;

			StackLayout panel = new StackLayout();
			panel.Padding = 70;
			panel.Children.Add(label1);
			panel.Children.Add(b1);
			panel.Children.Add(b2);
			Content = panel;
		}

		private async void B1_Clicked(object sender, EventArgs e) {
			await DisplayAlert("Error", "Invalid input", "OK");
		}

		private async void B2_Clicked(object sender, EventArgs e) {
			string result = await DisplayActionSheet("Action Title", "Cancel", null,
												"Red", "Green", "Blue");
			label1.Text = result;
		}
	}
}