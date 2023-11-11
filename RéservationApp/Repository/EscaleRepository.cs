using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class EscaleRepository : IEscaleRepository
    {
        private readonly DataContext _context;

        public EscaleRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateEscale(Escale escale)
        {
            _context.Add(escale);
            return Save();
        }

        public bool DeleteEscale(Escale escale)
        {
            _context.Remove(escale);
            return Save();
        }

        public bool EscaleExists(int ID)
        {
            return _context.Escales.Any(e => e.id == ID);
        }

        public Escale GetEscaleID(int ID)
        {
            return _context.Escales.Include(e => e.VolCargo).Where(e => e.id == ID).FirstOrDefault();
        }

        public ICollection<Escale> GetEscales()
        {
            return _context.Escales.Include(e => e.VolCargo).OrderBy(c => c.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEscale(Escale escale)
        {
            _context.Update(escale);
            return Save();
        }
    }
}
