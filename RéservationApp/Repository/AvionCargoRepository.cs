using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class AvionCargoRepository : IAvionCargoRepository
    {
        private readonly DataContext _context;

        public AvionCargoRepository(DataContext context) 
        {
            _context = context;
        }
        public bool AvionExists(int ID)
        {
            return _context.AvionCargos.Any(a => a.id == ID);
        }

        public bool CreateAvion(AvionCargo avion)
        {
            _context.Add(avion);
            return Save();
        }

        public bool DeleteAvion(AvionCargo avion)
        {
            _context.Remove(avion);
            return Save();
        }

        public AvionCargo GetAvion(int ID)
        {
            return _context.AvionCargos.Where(a => a.id == ID).FirstOrDefault();
        }

        public AvionCargo GetAvion(string modele)
        {
            return _context.AvionCargos.Where(a => a.AvionModele == modele).FirstOrDefault();
        }

        public ICollection<AvionCargo> GetAvionCargos()
        { 
            return _context.AvionCargos.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAvion(AvionCargo avion)
        {
            _context.Update(avion);
            return Save();
        }
    }
}
