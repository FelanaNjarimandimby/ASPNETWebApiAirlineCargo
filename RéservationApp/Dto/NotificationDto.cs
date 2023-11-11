namespace RéservationApp.Dto
{
    public class NotificationDto
    {
        public int id { get; set; }
        public string Vue { get; set; }
        public int ClientID { get; set; }
        public string ClientNom { get; set; }
        public int ReservationID { get; set; }
    }
}
