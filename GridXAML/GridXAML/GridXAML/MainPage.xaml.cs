using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GridXAML {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			Button senderbutton = sender as Button;
			if (resultLabel.Text.Equals("0"))
            {
				resultLabel.Text = senderbutton.Text;
            } else
            {
				resultLabel.Text += senderbutton.Text;
            }
		}

        private void Clear_Clicked(object sender, EventArgs e)
        {
			resultLabel.Text = "0";
        }
    }
}
