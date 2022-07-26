using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Accel {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			try {
				Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
				Accelerometer.Start(SensorSpeed.Default);
			}
			catch (FeatureNotSupportedException e) {
				x.Text = y.Text = z.Text = "Not supported";
			}
		}
		void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e) {
			var data = e.Reading;
			Device.BeginInvokeOnMainThread(() => {
				x.Text = "X = " + data.Acceleration.X.ToString();
				y.Text = "Y = " + data.Acceleration.Y.ToString();
				z.Text = "Z = " + data.Acceleration.Z.ToString();
			});
		}
	}
}
