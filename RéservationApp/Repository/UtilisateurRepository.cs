using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class UtilisateurRepository 
    {
        public readonly DataContext _context;

        public UtilisateurRepository(DataContext context)
        {
            _context = context;
        }

       /* public Utilisateur Authenticate(string mail, string mdp)
        {
            return _context.Utilisateurs.Where(u => u.Mail.ToUpper().Equals(mail.ToUpper())
            && u.MotPasse.Equals(mdp)).FirstOrDefault();
        } */
    }
}