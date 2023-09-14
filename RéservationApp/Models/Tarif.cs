using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Tarif
    {
        [Key]
        public int IDTarif { get; set; }
        public int Montant { get; set; }
        public ICollection<LTA> LTAs { get; set; }
    }
}
