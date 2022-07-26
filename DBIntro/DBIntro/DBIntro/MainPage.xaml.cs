using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;

namespace DBIntro
{
    public partial class MainPage : ContentPage
    {
        SQLiteConnection personsDBconn, userDBconn;
        public MainPage()
        {
            InitializeComponent();
            string libFolder = FileSystem.AppDataDirectory;
            string userDB = System.IO.Path.Combine(libFolder, "Personnel.db");
            userDBconn = new SQLiteConnection(userDB);
            userDBconn.CreateTable<User>();
            lv.ItemsSource = userDBconn.Table<User>().ToList();

            string personDB = System.IO.Path.Combine(libFolder, "Persons.db");
            personsDBconn = new SQLiteConnection(personDB);
            personsDBconn.CreateTable<Person>();
            lv2.ItemsSource = personsDBconn.Table<Person>().ToList();
        }

        private void addUserButton_Clicked(object sender, EventArgs e)
        {
            User newUser = new User { Username = username.Text };
            userDBconn.Insert(newUser);
            lv.ItemsSource = userDBconn.Table<User>().ToList();
        }


        private void addPersonButton_Clicked(object sender, EventArgs e)
        {
            Person newPerson = new Person { 
                Gender = isFemaleRadioButton.IsChecked,
                Name = name.Text,
                DOB = DOBPicker.Date,
                SSN = SSNEntry.Text,
                Income = Int32.Parse(IncomeEntry.Text)};
            personsDBconn.Insert(newPerson);
            lv2.ItemsSource = personsDBconn.Table<Person>().ToList();
        }
    }

}
