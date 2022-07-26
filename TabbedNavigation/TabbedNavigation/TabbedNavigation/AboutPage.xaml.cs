using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedNavigation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage {
        public AboutPage() {
            InitializeComponent();
            Padding = new Thickness(0, 50, 0, 0);
        }
    }
}