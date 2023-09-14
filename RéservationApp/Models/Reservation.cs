using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Reservation
    {
        [Key]
        public int RefReservation { get; set; }
        public string NomDestinaire { get; set;}
        public string AeroportDepart { get; set; }
        public string AeroportDestination { get; set; }
        public  DateTime DateExpeditionSouhaite { get; set; }
        public string ExigencesSpeciales { get; set; }
        public string EtatReservation { get; set; }
        public ICollection<LTA> LTAs { get; set; }
        public Client Client { get; set; }
        public Marchandise Marchandise { get; set; }
        public Vol Vol { get; set; }
    }
}
