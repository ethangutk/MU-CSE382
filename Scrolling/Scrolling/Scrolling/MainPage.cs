using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Scrolling {
    class MainPage : ContentPage {
        public const int N = 10;

        public MainPage() {
            StackLayout buttonPanel1 = new StackLayout();
            StackLayout buttonPanel2 = new StackLayout();

            for (int i = 0; i < N; i++) {
                buttonPanel1.Children.Add(new Button { Text = i.ToString() });
                buttonPanel2.Children.Add(new Button { Text = ((char)('A' + i)).ToString() });
            }

            ScrollView scrollView1 = new ScrollView { HeightRequest = 200, VerticalScrollBarVisibility = ScrollBarVisibility.Always };
            ScrollView scrollView2 = new ScrollView { HeightRequest = 200, VerticalScrollBarVisibility = ScrollBarVisibility.Always };

            scrollView1.Content = buttonPanel1;
            scrollView2.Content = buttonPanel2;


            StackLayout topLevel = new StackLayout();
            topLevel.Children.Add(scrollView1);
            topLevel.Children.Add(new BoxView { WidthRequest = 300, Color = Color.Red,
                                                HeightRequest = 10, HorizontalOptions = LayoutOptions.Center });
            topLevel.Children.Add(scrollView2);

            this.Content = topLevel;
        }
    }
}
