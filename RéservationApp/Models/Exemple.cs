using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Exemple
    {
        [Key]
        public int ID { get; set; }
        [Range(500, 100000)]
        public int chiffre { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string name
        {
            get { return firstname + ", " + lastname; }
        }
        public int cal1 { get; set; }
        public int cal2 { get; set; }
        public int cal
        {
            get { return cal1 + cal2; }  
        }
    }
}

