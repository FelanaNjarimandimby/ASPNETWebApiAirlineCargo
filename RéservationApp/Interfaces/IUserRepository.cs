using RéservationApp.Models;
using RéservationApp.Models.ModèleLogin;

namespace RéservationApp.Interfaces
{
    public interface IUserRepository
    {
        TblUser Authenticate(string username, string mdp, bool IsActive);
    }
}
