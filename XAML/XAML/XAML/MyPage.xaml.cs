using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();

            

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button senderbutton = sender as Button;
            if (resultsLabel.Text.Equals("0"))
            {
                resultsLabel.Text = senderbutton.Text;
            } else
            {
                resultsLabel.Text = resultsLabel.Text + senderbutton.Text;
            }
        }
    }
}