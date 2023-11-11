using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class CompagnieRepository : ICompagnieRepository
    {
        private readonly DataContext _context;

        public CompagnieRepository(DataContext context)
        {
            _context = context;
        }

        public bool CompagnieExists(int ID)
        {
            return _context.Compagnies.Any(a => a.id == ID);
        }

        public bool CreateCompagnie(Compagnie compagnie)
        {
            _context.Add(compagnie);
            return Save();
        }

        public bool DeleteCompagnie(Compagnie compagnie)
        {
            _context.Remove(compagnie);
            return Save();
        }

        public Compagnie GetCompagnie(int ID)
        {
            return _context.Compagnies.Where(a => a.id == ID).FirstOrDefault();
        }

        public ICollection<Compagnie> GetCompagnies()
        {
            return _context.Compagnies.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCompagnie(Compagnie compagnie)
        {
            _context.Update(compagnie);
            return Save();
        }
    }
}
