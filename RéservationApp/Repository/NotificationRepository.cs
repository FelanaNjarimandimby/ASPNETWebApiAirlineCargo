using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly DataContext _context;

        public NotificationRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNotification(Notification notification)
        {
            _context.Add(notification);
            return Save();
        }

        public bool DeleteNotification(Notification notification)
        {
            _context.Remove(notification);
            return Save();
        }

        public ICollection<Notification> GetAllNotification(string vue)
        {
            return _context.Notifications.Include(n => n.Reservation).Include(n => n.Client).
                Where(n => n.Vue == vue).ToList();
        }

        public Notification GetNotification(int reservation)
        {
            return _context.Notifications.Include(n => n.Reservation).Include(n => n.Client)
                .Where(n => n.Reservation.id == reservation).FirstOrDefault();
        }

        public Notification GetNotificationID(int ID)
        {
            return _context.Notifications.Include(n => n.Reservation).Include(n => n.Client)
                .Where(n => n.id == ID).FirstOrDefault();
        }

        public Notification GetNotificationNom(string Nom)
        {
            return _context.Notifications.Include(n => n.Reservation).Include(n => n.Client)
                .Where(n => n.Client.ClientNom == Nom).FirstOrDefault();
        }

        public ICollection<Notification> GetNotifications()
        {
            return _context.Notifications.Include(n => n.Reservation).Include(n => n.Client).ToList();
        }

        public bool NotificationExists(int ID)
        {
            return _context.Notifications.Any(n => n.id == ID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNotification(Notification notification)
        {
            _context.Update(notification);
            return Save();
        }
    }
}
