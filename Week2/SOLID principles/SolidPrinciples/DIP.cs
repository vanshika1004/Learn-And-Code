using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_principles
{
    internal class DIP
    {
        public static void Run()
        {
            // Email notification
            INotificationSender emailSender = new EmailNotificationSender();
            NotificationManager notificationManager = new NotificationManager(emailSender);

            notificationManager.SendNotification(
                "user@example.com",
                "Your Insurance policy has been renewed."
            );

            INotificationSender smsSender = new SmsNotificationSender();
            notificationManager = new NotificationManager(smsSender);

            notificationManager.SendNotification(
                "9999999999",
                "Your OTP is 1234."
            );

        }
    }
    //DIP - Dependency Inversion Principle - High‑level modules depend on abstractions, not on concrete classes.
    interface INotificationSender
    {
        void Send(string recipient, string content);
    }

    class NotificationManager
    {
        private readonly INotificationSender _notificationSender;

        public NotificationManager(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void SendNotification(string recipient, string content)
        {
            _notificationSender.Send(recipient, content);
        }
    }

    class EmailNotificationSender : INotificationSender
    {
        public void Send(string recipient, string content)
        {
            Console.WriteLine($"Email sent to {recipient}: {content}");
        }
    }

    class SmsNotificationSender : INotificationSender
    {
        public void Send(string recipient, string content)
        {
            Console.WriteLine($"SMS sent to {recipient}: {content}");
        }
    }
}
