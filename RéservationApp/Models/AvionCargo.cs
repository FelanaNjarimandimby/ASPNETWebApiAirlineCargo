using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class AvionCargo
    {
        [Key]
        public int id { get; set; }
        public string AvionModele { get; set;}
        public double AvionCapacite { get; set;}
        public ICollection<VolCargo> VolCargos { get; set;}
    }
}
