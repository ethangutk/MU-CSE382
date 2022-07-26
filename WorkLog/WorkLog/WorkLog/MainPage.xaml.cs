using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Reflection;
using System.IO;
using SQLite;

namespace WorkLog
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public static SQLiteConnection JobDBconn;
        public MainPage()
        {
            InitializeComponent();

            string DBName = "JobDB.db";
            string libFolder = FileSystem.AppDataDirectory;
            string jobDB = System.IO.Path.Combine(libFolder, DBName);

            JobDBconn = new SQLiteConnection(jobDB);
            JobDBconn.CreateTable<Job>();
        }
    }
}
