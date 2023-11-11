using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Vente
    {
        [Key]
        public int id { get; set; }
        public DateTime VenteDate { get; set; }
        public Reservation Reservation { get; set; }
        public Agent Agent { get; set; }
        public ICollection<LTA> LTAs { get; set; }
    }
}
