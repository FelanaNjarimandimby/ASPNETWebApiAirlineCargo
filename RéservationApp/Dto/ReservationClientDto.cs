namespace RéservationApp.Dto
{
    public class ReservationClientDto
    {
        public int id { get; set; }
        public string NomDestinataire { get; set; }
        public DateTime DateExpeditionSouhaite { get; set; }
        public string ReservationExigences { get; set; }
        public string ReservationEtat { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Designation { get; set; }
        public int NombreColis { get; set; }
        public double Poids { get; set; }
        public double Volume { get; set; }
        public string Nature { get; set; }
        public string Tarif { get; set; }
        public string ItineraireDepart { get; set; }
        public string ItineraireArrive { get; set; }

        public int ClientID { get; set; }
        public int VolID { get; set; }
    }
}
