using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class LtaRepository : ILtaRepository
    {
        private readonly DataContext _context;

        public LtaRepository(DataContext context)
        {
             _context = context;
        }

        public bool CreateLta(LTA lta)
        {
            _context.Add(lta);
            return Save();
        }

        public LTA GetLta(int id)
        {
            return _context.LTAs.Where(l => l.NumLTA == id).FirstOrDefault();
        }

        public ICollection<LTA> GetLtas()
        {
            return _context.LTAs.ToList();
        }

        public bool LtaExists(int LtaID)
        {
            return _context.LTAs.Any(l => l.NumLTA == LtaID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
