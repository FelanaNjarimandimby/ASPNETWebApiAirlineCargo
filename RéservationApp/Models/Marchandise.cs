using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Marchandise
    {
        [Key]
        public int id { get; set; }
        public string MarchandiseDesignation { get; set; }
        public int MarchandiseNombre { get; set; }
        public double MarchandisePoids { get; set;}
        public double MarchandiseVolume { get; set; }
        public Nature_Marchandise Nature_Marchandise { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
