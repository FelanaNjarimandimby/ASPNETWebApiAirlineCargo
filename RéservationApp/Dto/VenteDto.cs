namespace RéservationApp.Dto
{
    public class VenteDto
    {
        public int id { get; set; }
        public DateTime VenteDate { get; set; }
        public int ReservationID { get; set; }
        public int AgentID { get; set; }
    }
}
