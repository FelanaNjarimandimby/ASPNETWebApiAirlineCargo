using RéservationApp.Models;

namespace RéservationApp.Dto
{
    public class ReservationDto
    {
        public int id { get; set; }
        public string NomDestinataire { get; set; }
        public DateTime DateExpeditionSouhaite { get; set; }
        public string ReservationExigences { get; set; }
        public string ReservationEtat { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ClientID { get; set; }
        public int MarchandiseID { get; set; }
        public int VolID { get; set; }
        public int ItineraireID { get; set; }

    }
}
