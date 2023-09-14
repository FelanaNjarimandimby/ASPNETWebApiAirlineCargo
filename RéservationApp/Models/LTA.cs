using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class LTA
    {
        [Key]
        public int NumLTA { get; set; }
        public int RefReservation { get; set; }
        public int IDTarif { get; set; }
        public DateTime DateLTA { get; set;}
        public ICollection<Vente> Ventes { get; set; }
        public Reservation Reservation { get; set; }
        public Tarif Tarif { get; set; }
    }
}
