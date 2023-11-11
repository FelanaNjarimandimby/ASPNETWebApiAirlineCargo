using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Nature_Marchandise
    {
        [Key]
        public int id { get; set; }
        public  string NatureMarchandiseLibelle { get; set; }
        public TypeTarif TypeTarif { get; set; }
        public ICollection<Marchandise> Marchandises { get; set; }
        
    }
}
