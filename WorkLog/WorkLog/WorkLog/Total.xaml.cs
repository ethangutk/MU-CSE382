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
    public partial class Total : ContentPage
    {
        public Total()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            updateList();
        }

        public void updateList()
        {
            var jobTable = MainPage.JobDBconn.Table<Job>();
            Console.WriteLine(Settings.currentDisplayed);
            
            if (Settings.currentDisplayed.Equals("By Job Site"))
            {
                //         Name   , Job
                Dictionary<String, Job> createdSorted = new Dictionary<string, Job>(); ;

                foreach (Job j in jobTable.ToList())
                {
                    if (!createdSorted.ContainsKey(j.NameOfJob))
                    {
                        createdSorted.Add(j.NameOfJob, j);
                    } else
                    {
                        Job updatedEntry = createdSorted[j.NameOfJob];
                        updatedEntry.DurationMins  += j.DurationMins;
                        updatedEntry.DurationHours += j.DurationHours;
                        updatedEntry.TimeString = updatedEntry.CreateTimeString(updatedEntry.DurationMins, updatedEntry.DurationHours);

                        createdSorted[j.NameOfJob] = updatedEntry;
                    }
                }
                Console.WriteLine(createdSorted.Count);
                totalListView.ItemsSource = createdSorted.Values.ToList();
                totalListView.ItemTemplate = CreateTemp("NameOfJob");
            } else
            {
                //         Date    , Job
                Dictionary<DateTime, Job> createdSorted = new Dictionary<DateTime, Job>(); ;

                foreach (Job j in jobTable.ToList())
                {
                    if (!createdSorted.ContainsKey(j.DateOfJob))
                    {
                        createdSorted.Add(j.DateOfJob, j);
                    }
                    else
                    {
                        Job updatedEntry = createdSorted[j.DateOfJob];
                        updatedEntry.DurationMins += j.DurationMins;
                        updatedEntry.DurationHours += j.DurationHours;
                        updatedEntry.TimeString = updatedEntry.CreateTimeString(updatedEntry.DurationMins, updatedEntry.DurationHours);

                        createdSorted[j.DateOfJob] = updatedEntry;
                    }
                }
                Console.WriteLine(createdSorted.Count);
                totalListView.ItemsSource = createdSorted.Values.ToList();
                totalListView.ItemTemplate = CreateTemp("DateOfJob");
            }
        }

        DataTemplate CreateTemp(string name)
        {
            DataTemplate r = new DataTemplate(() => {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, name);
                nameLabel.FontSize = 16;
                nameLabel.TextColor = Color.Blue;

                Label hoursLabel = new Label();
                hoursLabel.SetBinding(Label.TextProperty, "TimeString");
                hoursLabel.FontSize = 16;
                hoursLabel.FontAttributes = FontAttributes.Italic;
                hoursLabel.TextColor = Color.Green;

                StackLayout sl = new StackLayout();
                sl.Orientation = StackOrientation.Horizontal;
                sl.Children.Add(nameLabel);
                sl.Children.Add(hoursLabel);
                return new ViewCell
                {
                    View = sl
                };
            });
            return r;
        }
    }
}