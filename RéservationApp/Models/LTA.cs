using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class LTA
    {
        [Key]
        public int id { get; set; }
        public string LTANumero { get; set; }
        public DateTime LTADateEmission { get; set;}
        public Vente Vente { get; set; }
    }
}
