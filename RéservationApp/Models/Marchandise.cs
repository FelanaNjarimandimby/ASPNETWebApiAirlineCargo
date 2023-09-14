using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Marchandise
    {
        [Key]
        public int IDMarchandise { get; set; }
        public string Designation { get; set; }
        public int NombreColis { get; set; }
        public double Poids { get; set;}
        public double Dimension { get; set;}
        public string Volume { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public Nature_Marchandise Nature_Marchandise { get; set; }
    }
}
