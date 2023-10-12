using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Data;
using RéservationApp.Models.ModèleLogin;

namespace RéservationApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : Controller
    {
        public readonly DataContext _context;

        public UserMasterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TblUser> Get()
        {
            return _context.TblUser.ToList();
        }

        [HttpGet("{id}")]
        public TblUser Get(string id)
        {
            return _context.TblUser.FirstOrDefault(o => o.Userid == id);
        }

        [HttpPost("Save")]
        public APIResponse Save([FromBody] TblUser value)
        {
            string result = string.Empty;
            try
            {
                var _emp = _context.TblUser.FirstOrDefault(o => o.Userid == value.Userid);
                if (_emp != null)
                {
                    _emp.Role = value.Role;
                    _emp.Email = value.Email;
                    _emp.Name = value.Name;
                    _emp.IsActive = value.IsActive;
                    _context.SaveChanges();
                    result = "pass";
                }
                else
                {
                    TblUser tblUser = new TblUser()
                    {
                        Name = value.Name,
                        Email = value.Email,
                        Userid = value.Userid,
                        Role = value.Role,
                        Password = string.Empty,
                        IsActive = true
                    };
                    _context.TblUser.Add(tblUser);
                    _context.SaveChanges();
                    result = "pass";
                }

            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return new APIResponse { keycode = string.Empty, result = result };
        }

        [HttpPost("ActivateUser")]
        public APIResponse ActivateUser([FromBody] TblUser value)
        {
            string result = string.Empty;
            try
            {
                var _emp = _context.TblUser.FirstOrDefault(o => o.Userid == value.Userid);
                if (_emp != null)
                {
                    _emp.Role = value.Role;
                    _emp.IsActive = value.IsActive;
                    _context.SaveChanges();
                    result = "pass";
                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return new APIResponse { keycode = string.Empty, result = result };
        }

        [HttpDelete("{id}")]
        public APIResponse Delete(string id)
        {
            string result = string.Empty;
            var _emp = _context.TblUser.FirstOrDefault(o => o.Userid == id);
            if (_emp != null)
            {
                _context.TblUser.Remove(_emp);
                _context.SaveChanges();
                result = "pass";
            }
            return new APIResponse { keycode = string.Empty, result = result };
        }

    }
}
