using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class AeroportRepository : IAeroportRepository
    {
        private DataContext _context;

        public AeroportRepository(DataContext context) 
        { 
            _context = context;
        }

        public bool AeroportExists(int ID)
        {
            return _context.Aeroports.Any(a => a.id == ID);
        }

        public bool CreateAeroport(Aeroport aeroport)
        {
            _context.Add(aeroport);
            return Save();
        }

        public bool DeleteAeroport(Aeroport aeroport)
        {
            _context.Remove(aeroport);
            return Save();
        }

        public Aeroport GetAeroportID(int ID)
        {
            return _context.Aeroports.Include(a => a.Compagnie).Where(a => a.id == ID).FirstOrDefault();
        }

        public ICollection<Aeroport> GetAeroports()
        {
            return _context.Aeroports.Include(a => a.Compagnie).OrderBy(c => c.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAeroport(Aeroport aeroport)
        {
           _context.Update(aeroport);
           return Save();
        }
    }
}
