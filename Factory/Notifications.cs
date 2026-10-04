namespace Factory
{

    // Creational Centerlized Factory Design Pattern
    // SubClass decides which class to instantiate based on the input parameter
    public enum NotificationType
    {
        Email = 1,
        WhatsApp = 2,
        SMS = 3,
        PushNotification = 4
    }
    

    // Base class
    public abstract class Notifications
    {
        public abstract void Send(string message);

        public static Notifications CreateNotification(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.WhatsApp => new WhatsAppNotification(),
                NotificationType.SMS => new SMSNotification(),
                NotificationType.PushNotification => new PushNotification(),

                _ => throw new ArgumentException(
                    $"Unsupported notification type: {type}")
            };
        }
    }

    // Email Notification
    public class EmailNotification : Notifications
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    // WhatsApp Notification
    public class WhatsAppNotification : Notifications
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Sending WhatsApp: {message}");
        }
    }

    // SMS Notification
    public class SMSNotification : Notifications
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // Push Notification
    public class PushNotification : Notifications
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }
}