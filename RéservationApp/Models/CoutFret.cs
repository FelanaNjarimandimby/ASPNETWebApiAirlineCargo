using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class CoutFret
    {
        [Key]
        public int id { get; set; }
        public double CoutPoidsMin { get; set; }
        public double CoutPoidsMax { get; set; }
        public double Cout { get; set; }
        public Agent Agent { get; set; }
    }
}
