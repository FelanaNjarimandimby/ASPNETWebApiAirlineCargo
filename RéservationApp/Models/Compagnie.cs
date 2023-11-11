using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Compagnie
    {
        [Key]
        public int id { get; set; }
        public string CompagnieNom { get; set; }
        public ICollection<Aeroport> Aeroports { get; set; }
    }
}
