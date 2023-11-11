using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Aeroport
    {
        [Key]
        public int id { get; set; }
        public string AeroportCodeIATA { get; set; }
        public string AeroportCodeOACI { get; set; }
        public string AeroportNom { get; set; }
        public string AeroportContact { get; set; }
        public string AeroportLocalisation { get; set; }
        public Compagnie Compagnie { get; set; }
        public ICollection<VolCargo> VolCargos { get; set; }
    }
}
