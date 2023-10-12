using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RéservationApp.Models.ModèleLogin
{
    public class TblRefreshtoken
    {
        public string UserId { get; set; }
        
        public string TokenId { get; set; }
        
        public string RefreshToken { get; set; }
        
        public bool? IsActive { get; set; }
    }
}
