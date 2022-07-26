using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace LocalNotifications {
    public partial class MainPage : ContentPage {
        const int SECONDS = 5;
        INotificationManager notificationManager;
        int notificationNumber = 0;

        public MainPage() {
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.TimerNotificationReceived += (sender, eventArgs) => {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowTimerNotification(evtData.Title, evtData.Message);
            };
            notificationManager.CalendarNotificationReceived += (sender, eventArgs) => {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowCalendarNotification(evtData.Title, evtData.Message);
            };
        }

        void OnIntervalClick(object sender, EventArgs e) {
            notificationNumber++;
            string title = $"Timer in {SECONDS}";
            string message = $"Notifications received {notificationNumber}";
            notificationManager.ScheduleTimerNotification(title, message, SECONDS);
        }

        void OnCalendarClick(object sender, EventArgs e) {
            DateTime when = DateTime.Now + new TimeSpan(0, 0, SECONDS);
            notificationNumber++;
            string title = $"Calendar at {when}";
            string message = $"Notifications received {notificationNumber}";
            notificationManager.ScheduleCalendarNotification(title, message, when);
        }
        void ShowTimerNotification(string title, string message) {
            Device.BeginInvokeOnMainThread(() => {
                var msg = new Label() {
                    Text = $"Timer Received:\nTitle: {title}\nMessage: {message}",
                    TextColor = Color.Green
                };
                stackLayout.Children.Add(msg);
            });
        }
        void ShowCalendarNotification(string title, string message) {
            Device.BeginInvokeOnMainThread(() => {
                var msg = new Label() {
                    Text = $"Calendar Received:\nTitle: {title}\nMessage: {message}",
                    TextColor = Color.Red
                };
                stackLayout.Children.Add(msg);
            });
        }
    }
}
