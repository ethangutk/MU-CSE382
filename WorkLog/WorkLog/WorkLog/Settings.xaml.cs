using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;

namespace WorkLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public static string currentDisplayed = "By Job Site";

        List<string> settingsOption = new List<string>()
        {
            "By Date", "By Job Site"
        };

        public Settings()
        {
            InitializeComponent();
            displayListSetting.ItemsSource = settingsOption;
            if (!Preferences.ContainsKey("Sort_Setting"))
                Preferences.Set("Sort_Setting", "By Job Site");
            displayListSetting.SelectedItem = Preferences.Get("Sort_Setting", "By Job Site");
            currentDisplayed = Preferences.Get("Sort_Setting", "By Job Site");
        }

        private void redirectToCreditsButton_Clicked(object sender, EventArgs e)
        {
            // I could not get this method to work,
            // the articles I came accross did not provide with
            // a correct solution.
            try
            {
                // Process.Start("https://www.miamioh.edu/");
                System.Diagnostics.Process.Start("https://www.miamioh.edu/");
            }
            catch
            { }
        }

        private void displayListSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (displayListSetting.SelectedItem != null)
            {
                Preferences.Set("Sort_Setting", displayListSetting.SelectedItem.ToString());
                currentDisplayed = Preferences.Get("Sort_Setting", "By Job Site");
            }
            
        }
    }
}