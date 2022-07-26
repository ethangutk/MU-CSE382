using System;

namespace LocalNotifications
{
    public interface INotificationManager {
        event EventHandler TimerNotificationReceived;
        event EventHandler CalendarNotificationReceived;

        void Initialize();
        int ScheduleTimerNotification(string title, string message, int seconds);
        void ReceiveTimerNotification(string title, string message);
        int ScheduleCalendarNotification(string title, string message, DateTime when);
        void ReceiveCalendarNotification(string title, string message);
    }
}
