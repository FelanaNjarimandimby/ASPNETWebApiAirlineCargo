using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class VolCargo
    {
        [Key]
        public int id { get; set; }
        public string VolNumero { get; set; }
        public string VolStatut { get; set; }
        public DateTime VolDateHeureDepart { get; set; }
        public DateTime VolDateHeureArrivee { get; set; }
        public AvionCargo AvionCargo { get; set; }
        public Aeroport Aeroport { get; set; }
        public Itineraire Itineraire { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Escale> Escales { get; set; }
    }
}
