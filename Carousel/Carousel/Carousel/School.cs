using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carousel {
    class School : ContentPage {
        public School(String url) {
            WebView wv = new WebView { Source = url };
            this.Content = wv;
        }
    }
}
