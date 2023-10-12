using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class CoutFret
    {
        [Key]
        public int IDCout { get; set; }
        public double PoidsMin { get; set; }
        public double PoidsMax { get; set; }
        public double Cout { get; set; }
    }
}
