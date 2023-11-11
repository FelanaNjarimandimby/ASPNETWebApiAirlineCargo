using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Escale
    {
        [Key]
        public int id { get; set; }
        public string EscaleNumero { get; set;}
        public string EscaleVille { get; set;}
        public VolCargo VolCargo { get; set; }
    }
}
