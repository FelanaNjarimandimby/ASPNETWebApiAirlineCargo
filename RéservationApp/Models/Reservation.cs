using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }
        public string NomDestinataire { get; set;}
        public  DateTime DateExpeditionSouhaite { get; set; }
        public string ReservationExigences { get; set; }
        public string ReservationEtat { get; set; }
        public DateTime ReservationDate { get; set; }
        public Client Client { get; set; }
        public Marchandise Marchandise { get; set; }
        public VolCargo VolCargo { get; set; }
        public Itineraire Itineraire { get; set; }
        public ICollection<Vente> Ventes { get; set; }
        public ICollection<Notification> Notifications { get; set; }

    }
}
