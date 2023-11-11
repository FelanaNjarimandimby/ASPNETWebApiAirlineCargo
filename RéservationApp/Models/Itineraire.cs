namespace RéservationApp.Models
{
    public class Itineraire
    {
        public int id { get; set; }
        public string ItineraireDepart { get; set; }
        public string ItineraireArrive { get; set; }
        public ICollection<VolCargo> VolCargos { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
