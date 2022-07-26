using System;
using UserNotifications;
using Xamarin.Forms;

namespace LocalNotifications.iOS {
    public class iOSNotificationReceiver : UNUserNotificationCenterDelegate {
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler) {
            if (notification.Request.Trigger.GetType() == typeof(UNTimeIntervalNotificationTrigger))
                DependencyService.Get<INotificationManager>().ReceiveTimerNotification(notification.Request.Content.Title, notification.Request.Content.Body);
            else
                DependencyService.Get<INotificationManager>().ReceiveCalendarNotification(notification.Request.Content.Title, notification.Request.Content.Body);

            // alerts are always shown for demonstration but this can be set to "None"
            // to avoid showing alerts if the app is in the foreground
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
    }
}