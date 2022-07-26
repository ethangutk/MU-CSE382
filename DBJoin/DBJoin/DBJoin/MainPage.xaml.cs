using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;

namespace DBJoin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SQLiteConnection conn;

        public MainPage()
        {
            InitializeComponent();
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "Cars.db");
            conn = new SQLiteConnection(fname);
            conn.CreateTable<Manufacturer>();
            conn.CreateTable<Model>();
            conn.DeleteAll<Manufacturer>();
            conn.DeleteAll<Model>();
            conn.Insert(new Manufacturer { Name = "Ford", Headquarters = "Detroit, MI" });
            conn.Insert(new Manufacturer { Name = "GM", Headquarters = "Detroit, MI" });
            conn.Insert(new Manufacturer { Name = "Suburu", Headquarters = "Toyyo, Japan" });
            conn.Insert(new Manufacturer { Name = "BMW", Headquarters = "Munich, Germany" });

            conn.Insert(new Model { Name = "Focus", Make = "Ford" });
            conn.Insert(new Model { Name = "Mustang", Make = "Ford" });
            conn.Insert(new Model { Name = "F-150", Make = "Ford" });
            conn.Insert(new Model { Name = "Cruze", Make = "GM" });
            conn.Insert(new Model { Name = "Camero", Make = "GM" });
            conn.Insert(new Model { Name = "Forester", Make = "Suburu" });
            conn.Insert(new Model { Name = "i8", Make = "BMW" });
            conn.Insert(new Model { Name = "X5", Make = "BMW" });

            lv.ItemsSource = from model in conn.Table<Model>()
                             join manufacturer in conn.Table<Manufacturer>() on model.Make equals manufacturer.Name
                             select new { ModelName = model.Name, ManufacturerName = manufacturer.Name, HQ = manufacturer.Headquarters };



        }
    }
}
