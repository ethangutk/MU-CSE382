using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carousel {
    public partial class App : Application {
        public string[] urls = { "www.miamioh.edu", "www.osu.edu", "www.uc.edu" };
        public App() {
            InitializeComponent();

            CarouselPage carouselPage = new CarouselPage();
            foreach (string url in urls) {
                School schoolPage = new School("https://" + url);
                schoolPage.Padding = new Thickness(0, 40, 0, 0);
                carouselPage.Children.Add(schoolPage);
            }
            MainPage = carouselPage;
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
