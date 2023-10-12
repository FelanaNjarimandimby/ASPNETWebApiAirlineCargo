using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models.ModèleLogin;

namespace RéservationApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        TblUser IUserRepository.Authenticate(string username, string mdp, bool IsActive)
        {
            return _context.TblUser.Where(u => u.Name.ToUpper().Equals(username.ToUpper())
                   && u.Password.Equals(mdp) && u.IsActive.Equals(IsActive)).FirstOrDefault();
        }
    }
}
