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

        public Vente GetVente(int id)
        {
            return _context.Ventes.Where(v => v.IDVente == id).FirstOrDefault();
        }

        public ICollection<Vente> GetVentes()
        {
            return _context.Ventes.OrderBy(v => v.IDVente).ToList();
        }

        public bool VenteExists(int venteID)
        {
            return _context.Ventes.Any(v => v.IDVente == venteID);
        }
    }
}
