using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class TypeTarif
    {
        [Key]
        public int id { get; set; }
        public string TarifLibelle { get; set; }
        public double TarifValeur { get; set; }
        public double TarifFraisAssurance { get; set; }
        public double TarifAnnexe { get; set; }
        public ICollection<Nature_Marchandise> Nature_Marchandises { get; set; }

    }
}
