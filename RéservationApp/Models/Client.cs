using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public  string ClientNom { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientAdresse { get; set; }
        public string ClientMail { get; set;}
        public string ClientContact { get; set; }
        public string ClientMotPasse { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}

