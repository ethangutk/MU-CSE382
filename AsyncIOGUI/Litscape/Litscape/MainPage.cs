using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Litscape {
    class MainPage : ContentPage {
        EnglishDictionary words;
        Entry letters;
        Label hasBeenFound;
        public MainPage() {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Litscape.words.txt");
            words = new EnglishDictionary(new StreamReader(stream));
            Debug.WriteLine("?");
            StackLayout panel = new StackLayout();

            letters = new Entry { Text = "apples" };
            hasBeenFound = new Label { Text = "-------" };
            Button b = new Button { Text = "Lookup" };
            b.Clicked += OnFindClicked;

            panel.Children.Add(letters);
            panel.Children.Add(hasBeenFound);
            panel.Children.Add(b);
            panel.Padding = 72;

            this.Content = panel;
        }

        private void OnFindClicked(object sender, EventArgs e) {
            hasBeenFound.Text = words.IsLegal(letters.Text).ToString();
        }
    }
}
