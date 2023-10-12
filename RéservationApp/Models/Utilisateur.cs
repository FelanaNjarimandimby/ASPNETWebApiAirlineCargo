using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Utilisateur
    {
        [Key]
        public int IDUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string MotPasse { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
