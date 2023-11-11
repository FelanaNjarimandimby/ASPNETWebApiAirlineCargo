namespace RéservationApp.Dto
{
    public class LtaDto
    {
        public int id { get; set; }
        public string LTANumero { get; set; }
        public DateTime LTADateEmission { get; set; }
        public DateTime DateVente { get; set; }
        public int VenteID { get; set; }
        public string AgentNom { get; set; }
        public string AgentContact { get; set; }
        public string ClientNom { get; set; }
        public string ClientContact { get; set; }
        public string Destinataire { get; set; }
        public string MarchandiseDesignation { get; set; }
        public int MarchandiseNombre { get; set; }
        public double MarchandisePoids { get; set; }
        public double MarchandiseVolume{ get; set; }
        public string Nature { get; set; }
        public string Tarif { get; set; }
        public string VolNumero { get; set; }
        public string DateHeureDepart { get; set; }
        public string DateHeureArrive { get; set; }
        public string ItineraireDepart { get; set; }
        public string ItineraireArrive { get; set; }
        public string AvionModele { get; set; }
        public string AvionCapacite { get; set; }
        public string AeroportNom { get; set; }
        public string AeroportContact { get; set; }
        public string AeroportLocalisation { get; set; }
        public string CompagnieNom { get; set; }
    }
}
