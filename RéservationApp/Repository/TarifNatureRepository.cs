using Newtonsoft.Json.Linq;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Models.ModèleLogin;

namespace RéservationApp.Repository
{
    public class TarifNatureRepository : ITarifNatureRepository
    {
        private readonly DataContext _context;

        public TarifNatureRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTarifNature(TarifNature tarifNature)
        {
            _context.Add(tarifNature);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
    
}
