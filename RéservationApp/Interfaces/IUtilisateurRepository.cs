using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IUtilisateurRepository
    {
        Utilisateur Authenticate(string mail, string mdp);
        //       string  GenerateToken(string secret, List<Claim> claims);
    }
}
