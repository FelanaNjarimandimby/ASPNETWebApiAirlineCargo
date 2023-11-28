using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class VenteRepository : IVenteRepository
    {
        private DataContext _context;

        public VenteRepository(DataContext context) 
        { 
            _context = context;
        }

        public bool CreateVente(Vente vente)
        {
            _context.Add(vente);
            return Save();
        }

        public bool DeleteVente(Vente vente)
        {
            _context.Remove(vente);
            return Save();
        }

        public Vente GetVente(int VenteID)
        {
            return _context.Ventes.Include(v => v.Reservation).Include(v => v.Agent).Where(v => v.id == VenteID).OrderBy(v => v.id).FirstOrDefault();
        }

        public ICollection<Vente> GetVentes()
        {
            return _context.Ventes.Include(v => v.Reservation).Include(v => v.Agent).OrderBy(v => v.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVente(Vente vente)
        {
            _context.Update(vente);
            return Save();
        }

        public bool VenteExists(int ID)
        {
            return _context.Ventes.Any(v => v.id == ID);
        }
    }
}
