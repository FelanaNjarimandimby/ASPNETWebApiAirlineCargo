using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Vente
    {
        [Key]
        public int IDVente { get; set; }
        public DateTime DateVente { get; set; }
        public LTA LTA { get; set; }
    }
}
