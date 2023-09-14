using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Utilisateur
    {
        [Key]
        public int IDUtilisaeur { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotPasse { get; set; }
    }
}
