using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace MobileFileSystem {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			LoadFiles();
		}
		public static string GetFullFileName(string basename) {
			string libFolder = FileSystem.AppDataDirectory;
			string fname = System.IO.Path.Combine(libFolder, basename);
			return fname;
		}
		private void NewClicked(object sender, EventArgs e) {
			WriteFile(name.Text, contents.Text);
			LoadFiles();
		}
		private void LoadFiles() {
			string libFolder = FileSystem.AppDataDirectory;
			string[] files = Directory.GetFiles(libFolder);
			for (int i = 0; i < files.Length; i++) {
				char sep = Path.DirectorySeparatorChar;
				int pos = files[i].LastIndexOf(sep);
				files[i] = files[i].Substring(pos+1);
			}
			filesLV.ItemsSource = files;
			if (files.Length > 0)
				filesLV.SelectedItem = files[0];
		}
		private void DeleteClicked(object sender, EventArgs e) {
			string fullName = GetFullFileName((string)filesLV.SelectedItem);
			File.Delete(fullName);
			LoadFiles();
		}
		private void WriteFile(string fname, string contents) {
			string fullName = GetFullFileName(fname);
			StreamWriter sr = new StreamWriter(fullName);
			sr.Write(contents);
			sr.Close();
		}
		private void UpdateClicked(object sender, EventArgs e) {
			if (filesLV.SelectedItem == null)
				return;
			WriteFile((string)filesLV.SelectedItem, contents.Text);
		}
		private void FileSelected(object sender, SelectedItemChangedEventArgs e) {
			if (filesLV.SelectedItem == null)
				return;
			string fname = GetFullFileName((string)filesLV.SelectedItem);
			StreamReader sr = new StreamReader(fname);
			contents.Text = sr.ReadToEnd();
			sr.Close();
		}
	}
}
