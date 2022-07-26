using System;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotifications.iOS.iOSNotificationManager))]
namespace LocalNotifications.iOS {
    public class iOSNotificationManager : INotificationManager {
        int messageId = -1;

        bool hasNotificationsPermission;

        public event EventHandler TimerNotificationReceived;
        public event EventHandler CalendarNotificationReceived;

        public void Initialize() {
            // request the permission to use local notifications
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) => {
                hasNotificationsPermission = approved;
            });
        }

        public int ScheduleTimerNotification(string title, string message, int seconds) {
            // EARLY OUT: app doesn't have permissions
            if (!hasNotificationsPermission) {
                return -1;
            }

            messageId++;

            var content = new UNMutableNotificationContent() {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            // Local notifications can be time or location based
            // Create a time-based trigger, interval is in seconds and must be greater than 0
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(seconds, false);

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null) {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });

            return messageId;
        }
        public int ScheduleCalendarNotification(string title, string message, DateTime when) {
            // EARLY OUT: app doesn't have permissions
            if (!hasNotificationsPermission) {
                return -1;
            }

            messageId++;

            var content = new UNMutableNotificationContent() {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            // Local notifications can be time or location based
            // Create a time-based trigger, interval is in seconds and must be greater than 0

            // var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(25, false);
            Foundation.NSDateComponents date = new Foundation.NSDateComponents {
                Day = when.Day,
                Month = when.Month,
                Year = when.Year,
                Hour = when.Hour,
                Minute = when.Minute,
                Second = when.Second
            };
            var trigger = UNCalendarNotificationTrigger.CreateTrigger(date, false);

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null) {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });

            return messageId;
        }
        public void ReceiveTimerNotification(string title, string message) {
            var args = new NotificationEventArgs() {
                Title = title,
                Message = message
            };
            TimerNotificationReceived?.Invoke(null, args);
        }
        public void ReceiveCalendarNotification(string title, string message) {
            var args = new NotificationEventArgs() {
                Title = title,
                Message = message
            };
            CalendarNotificationReceived?.Invoke(null, args);
        }
    }
}