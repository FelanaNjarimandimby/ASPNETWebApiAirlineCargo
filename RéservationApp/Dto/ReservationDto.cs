namespace RéservationApp.Dto
{
    public class ReservationDto
    {
        public int RefReservation { get; set; }
        public string NomDestinaire { get; set; }
        public string AeroportDepart { get; set; }
        public string AeroportDestination { get; set; }
        public DateTime DateExpeditionSouhaite { get; set; }
        public string ExigencesSpeciales { get; set; }
        public string EtatReservation { get; set; }
    }
}
