using RéservationApp.Models;
using RéservationApp.Models.ModèleLogin;

namespace RéservationApp.Interfaces
{
    public interface IRefreshTokenGenerator
    {
        string GenerateToken(string username);
        
    }
}
