using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Vol
    {
        [Key]
        public int NumVol { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateArrivee { get; set; }
        public string CapaciteChargement { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
