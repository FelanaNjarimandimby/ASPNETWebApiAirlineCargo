namespace RéservationApp.Dto
{
    public class VenteCargoDto
    {
        public int id { get; set; }
        public DateTime VenteDate { get; set; }
        public int ReservationID { get; set; }
        public string AgentNom { get; set; }
    }
}
