using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Nature_Marchandise
    {
        [Key]
        public int IDNatureMarchandise { get; set; }
        public  string Libelle { get; set; }
        public ICollection<Marchandise> Marchandises { get; set; }
    }
}
