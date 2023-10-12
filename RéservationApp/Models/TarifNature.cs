using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RéservationApp.Models
{
    public class TarifNature
    {
        [Key]
        public int IDTarifNature { get; set; }
        public double PoidsTaxable { get; set; }
        public string TypeTarif { get; set; }
        public Marchandise Marchandise { get; set; }
    }
}
