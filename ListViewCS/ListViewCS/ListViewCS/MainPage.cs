using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ListViewCS {
	public class MainPage : ContentPage {
		string[] initialItems = { "A" };

		ListView listViewOfStaticCollection;
		ListView listViewOfObservableCollection;
		ListView listViewOfManuallyUpdatedCollection;

		Entry entry;

		public List<string> standardList1;
		public List<string> standardList2;
		public ObservableCollection<string> observableCollection;

		public MainPage() {
			observableCollection = new ObservableCollection<string>();
			standardList1 = new List<string>();
			standardList2 = new List<string>();

			foreach (string item in initialItems) {
				observableCollection.Add(item);
				standardList1.Add(item);
				standardList2.Add(item);
			}

			listViewOfStaticCollection = new ListView();
			listViewOfManuallyUpdatedCollection = new ListView();
			listViewOfObservableCollection = new ListView();

			listViewOfStaticCollection.ItemsSource = standardList1;
			listViewOfManuallyUpdatedCollection.ItemsSource = standardList2;
			listViewOfObservableCollection.ItemsSource = observableCollection;

			entry = new Entry { Text = "some text" };
			Button addButton = new Button { Text = "Add" };
			addButton.Clicked += OnClicked;

			StackLayout topLevel = new StackLayout();

			topLevel.Children.Add(entry);
			topLevel.Children.Add(addButton);
			topLevel.Children.Add(listViewOfStaticCollection);
			topLevel.Children.Add(listViewOfManuallyUpdatedCollection);
			topLevel.Children.Add(listViewOfObservableCollection);
			topLevel.Padding = new Thickness(0, 40, 0, 0);

			Content = topLevel;
		}
		private void OnClicked(object sender, EventArgs e) {
			observableCollection.Add(entry.Text);
			standardList1.Add(entry.Text);
			standardList2.Add(entry.Text);
			listViewOfManuallyUpdatedCollection.ItemsSource = new List<string>(standardList2);
		}
	}
}
