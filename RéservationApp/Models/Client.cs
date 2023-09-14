using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        public  string  NomClient { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set;}
        public string Telephone { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
