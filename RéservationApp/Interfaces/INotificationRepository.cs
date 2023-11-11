using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface INotificationRepository
    {
        ICollection<Notification> GetNotifications();
        Notification GetNotificationID(int ID);

        Notification GetNotificationNom(string Nom);
        Notification GetNotification(int reservation);
        ICollection<Notification> GetAllNotification(string vue);
        bool NotificationExists(int ID);
        bool CreateNotification(Notification notification);
        bool UpdateNotification(Notification notification);
        bool DeleteNotification(Notification notification);
        bool Save();
    }
}
