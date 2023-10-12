using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class CoutFretRepository: ICoutFretRepository
    {
        private readonly DataContext _context;

        public CoutFretRepository(DataContext context)
        {
            _context = context;
        }

        public CoutFret GetCoutFret(double Poids)
        {
            return _context.CoutFrets.Where(c => c.PoidsMin <= Poids && c.PoidsMax >= Poids).FirstOrDefault();
        }

        public ICollection<CoutFret> GetCoutFrets()
        {
            return _context.CoutFrets.OrderBy(c => c.IDCout).ToList();
        }
    }
}
