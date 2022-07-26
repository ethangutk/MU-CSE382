using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace InputFiles {
	public class MainPage : ContentPage {
		// Within MS VS, the file data.txt has the property "Embedded Resource"
		// The file is readonly and is not editable.
		// Is located in the shared project within MS VS.
		const string FNAME = "data.txt";
		public Label edit;
		private static string GetFileContents(string fname) {
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
			string namespaceName = "InputFiles";
			Stream stream = assembly.GetManifestResourceStream(namespaceName + "." + fname);
			string text = "";
			using (var dictReader = new System.IO.StreamReader(stream)) {
				text = dictReader.ReadToEnd();
			}
			return text;
		}
		public MainPage() {
			StackLayout layout = new StackLayout();
			edit = new Label { Text = GetFileContents("data.txt") };
			layout.Children.Add(edit);
			layout.Padding = new Thickness(0, 40, 0, 0);
			Content = layout;
		}
	}
}
