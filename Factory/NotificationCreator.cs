using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    // Abstract Factory class 
    // Factory method pattern is used to create objects without specifying the exact class of object that will be created.
    public abstract class NotificationCreator
    {
        protected abstract Notifications CreateNotification();
        public void Notify(string message)
        {
            Notifications notification = CreateNotification();
            notification.Send(message);
        }
    }
}
