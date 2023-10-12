using Newtonsoft.Json.Linq;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models.ModèleLogin;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace RéservationApp.Repository
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public readonly DataContext _context;

        public RefreshTokenGenerator(DataContext context)
        {
            _context = context;
            
        }

        public string GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreshToken = Convert.ToBase64String(randomnumber);

                var _user = _context.TblRefreshtoken.FirstOrDefault(o => o.UserId == username);
                if (_user != null)
                {
                    _user.RefreshToken = RefreshToken;
                    _context.SaveChanges();
                }
                else
                {
                    TblRefreshtoken tblRefreshtoken = new TblRefreshtoken()
                    {
                        UserId = username,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken = RefreshToken,
                        IsActive = true
                    };
                }

                return RefreshToken;
            }
        }
    }
}
