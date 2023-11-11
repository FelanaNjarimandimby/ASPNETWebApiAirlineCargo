using System.Text.Json.Serialization;

namespace RéservationApp.Dto
{
    public class ClientDto
    {
        public int id { get; set; }
        public string ClientNom { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientAdresse { get; set; }
        public string ClientMail { get; set; }
        public string ClientContact { get; set; }
        public string ClientMotPasse { get; set; }
    }
}
