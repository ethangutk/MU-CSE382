using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Activities : ContentPage
    {
        List<int> hours = new List<int>()
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            };
        List<int> mins = new List<int>()
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
                13, 14, 15, 16, 17, 18, 19, 20, 21, 22,
                23, 24, 25, 26, 27, 28, 29, 30, 31, 32,
                33, 34, 35, 36, 37, 38, 39, 40, 41, 42,
                44, 45, 46, 47, 48, 49, 50, 51, 52, 53,
                54, 55, 56, 57, 58, 59
            };


        public Activities()
        {
            InitializeComponent();
            jobDurationHours.ItemsSource = hours;
            jobDurationMinutes.ItemsSource = mins;
            jobDurationHours.SelectedIndex = 0;
            jobDurationMinutes.SelectedIndex = 0;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var jobTable = MainPage.JobDBconn.Table<Job>();
            totalJobsList.ItemsSource = jobTable.OrderBy(s => s.DateOfJob).ToList();
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Job newEntry = new Job
            {
                NameOfJob = jobNameEntry.Text, DateOfJob = jobDatePicker.Date,
                DurationHours = jobDurationHours.SelectedIndex, DurationMins = jobDurationMinutes.SelectedIndex,
                OddHours = oddHoursCheckBox.IsChecked
            };
            newEntry.TimeString = newEntry.CreateTimeString(newEntry.DurationMins, newEntry.DurationHours);

            MainPage.JobDBconn.Insert(newEntry);
            totalJobsList.ItemsSource = 
                MainPage.JobDBconn.Table<Job>().ToList();
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            if (totalJobsList.SelectedItem != null)
            {
                // Deletes old item
                MainPage.JobDBconn.Delete(totalJobsList.SelectedItem);

                Job newEntry = new Job
                {
                    NameOfJob = jobNameEntry.Text,
                    DateOfJob = jobDatePicker.Date,
                    DurationHours = jobDurationHours.SelectedIndex,
                    DurationMins = jobDurationMinutes.SelectedIndex,
                    OddHours = oddHoursCheckBox.IsChecked
                };
                newEntry.TimeString = newEntry.CreateTimeString(newEntry.DurationMins, newEntry.DurationHours);

                MainPage.JobDBconn.Insert(newEntry);
                totalJobsList.ItemsSource =
                    MainPage.JobDBconn.Table<Job>().ToList();
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            if (totalJobsList.SelectedItem != null)
            {
                MainPage.JobDBconn.Delete(totalJobsList.SelectedItem);
                totalJobsList.ItemsSource =
                    MainPage.JobDBconn.Table<Job>().ToList();
            }
        }

        private void totalJobsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (totalJobsList.SelectedItem != null)
            {
                Job selectedItem = (Job)totalJobsList.SelectedItem;
                jobNameEntry.Text = selectedItem.NameOfJob;
                jobDatePicker.Date = selectedItem.DateOfJob;
                jobDurationHours.SelectedIndex = selectedItem.DurationHours;
                jobDurationMinutes.SelectedIndex = selectedItem.DurationMins;
                oddHoursCheckBox.IsChecked = selectedItem.OddHours;
            }
            
        }
    }
}