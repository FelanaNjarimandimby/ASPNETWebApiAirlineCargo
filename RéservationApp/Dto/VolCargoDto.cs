using RéservationApp.Models;

namespace RéservationApp.Dto
{
    public class VolCargoDto
    {
        public int id { get; set; }
        public string VolNumero { get; set; }
        public string VolStatut { get; set; }
        public DateTime VolDateHeureDepart { get; set; }
        public DateTime VolDateHeureArrivee { get; set; }
        public int AvionID { get; set; }
        public int AeroportID { get; set; }
        public int ItineraireID { get; set; }
    }
}
