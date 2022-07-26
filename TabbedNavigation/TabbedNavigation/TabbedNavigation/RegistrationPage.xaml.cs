using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedNavigation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage {
        public RegistrationPage() {
            InitializeComponent();
        }
        public string Name {
            get { return name.Text; }
        }
    }
}