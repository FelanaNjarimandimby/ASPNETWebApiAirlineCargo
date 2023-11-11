using Microsoft.EntityFrameworkCore;
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

        public bool CoutFretExists(int ID)
        {
            return _context.CoutFrets.Any(c => c.id == ID);
        }

        public bool CreateCoutFret(CoutFret coutFret)
        {
            _context.Add(coutFret);
            return Save();
        }

        public bool DeleteCoutFret(CoutFret coutFret)
        {
            _context.Remove(coutFret);
            return Save();
        }

        public CoutFret GetCoutFret(double Poids)
        {
            return _context.CoutFrets.Include(cf => cf.Agent).Where(c => c.CoutPoidsMin <= Poids && c.CoutPoidsMax >= Poids).FirstOrDefault();
        }

        public CoutFret GetCoutFretID(int ID)
        {
            return _context.CoutFrets.Include(cf => cf.Agent).Where(c => c.id == ID).FirstOrDefault();
        }

        public ICollection<CoutFret> GetCoutFrets()
        {
            return _context.CoutFrets.Include(cf => cf.Agent).OrderBy(c => c.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCoutFret(CoutFret coutFret)
        {
            _context.Update(coutFret);
            return Save();
        }
    }
}
