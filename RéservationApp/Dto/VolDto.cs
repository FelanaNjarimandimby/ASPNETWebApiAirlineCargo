namespace RéservationApp.Dto
{
    public class VolDto
    {
        public int id { get; set; }
        public string VolNumero { get; set; }
        public string VolStatut { get; set; }
        public DateTime VolDateHeureDepart { get; set; }
        public DateTime VolDateHeureArrivee { get; set; }
        public string AvionModele { get; set; }
        public string AeroportCodeIATA { get; set; }
        public string AeroportCodeOACI { get; set; }
        public string AeroportNom { get; set; }
        public string ItineraireDepart { get; set; }
        public string ItineraireArrive { get; set; }
    }
}
