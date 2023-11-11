using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Notification
    {
        [Key]
        public int id { get; set; }
        public string Vue { get; set; }
        public Reservation Reservation { get; set; }
        public Client Client { get; set; }
    }
}
