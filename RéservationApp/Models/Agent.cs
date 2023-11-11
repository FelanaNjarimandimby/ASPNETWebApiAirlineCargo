using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models
{
    public class Agent
    {
        [Key]
        public int id { get; set; }
        public string AgentNom { get; set; }
        public string AgentPrenom { get; set; }
        public string AgentGenre { get; set; }
        public string AgentAdresse { get; set; }
        public string AgentContact { get; set; }
        public string AgentFonction { get; set; }
        public string AgentMail { get; set; }
        public string AgentMotPasse { get; set; }
        public ICollection<CoutFret> CoutFrets { get; set; }
        public ICollection<Vente> Ventes { get; set; }
    }
}
