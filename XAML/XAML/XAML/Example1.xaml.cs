using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Example1 : ContentPage {
		int cTapped = 0, cSelected = 0;
		int rbTapped = 0, rbSelected = 0;
		int pTapped = 0, pSelected = 0;

		public Example1() {
			InitializeComponent();
		}
        private void OnTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item.Equals("Chicken")) {
                cTapped++;
                cLabel.Text = String.Format("Chicken {0} {1}", cSelected, cTapped);
            } else if (e.Item.Equals("Roast Beef")) {
                rbTapped++;
                rbLabel.Text = String.Format("Roast Beef {0} {1}", rbSelected, rbTapped);
            } else {
                pTapped++;
                pLabel.Text = String.Format("Pasta {0} {1}", pSelected, pTapped);
            }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem.Equals("Chicken")) {
                cSelected++;
                cLabel.Text = String.Format("Chicken {0} {1}", cSelected, cTapped);
            } else if (e.SelectedItem.Equals("Roast Beef")) {
                rbSelected++;
                rbLabel.Text = String.Format("Roast Beef {0} {1}", rbSelected, rbTapped);
            } else {
                pSelected++;
                pLabel.Text = String.Format("Pasta {0} {1}", pSelected, pTapped);
            }
        }
    }
}