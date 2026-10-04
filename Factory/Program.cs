using Factory;

class program
{
    static void Main(string[] args)
    {
        Notifications notification = Notifications.CreateNotification(NotificationType.Email);
        notification.Send("Hello, World!");
    }
}