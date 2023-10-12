using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class TypeTarif
    {
        [Key]
        public int IDTypeTarif { get; set; }
        public string LibelleTarif { get; set; }
        public double ValeurTarif { get; set; }
        public ICollection<Nature_Marchandise> Nature_Marchandises { get; set; }

    }
}
