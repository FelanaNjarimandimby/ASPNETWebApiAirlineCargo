using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class TarifRepository : ITarifRepository
    {
        public readonly DataContext _context;
        public TarifRepository(DataContext context)
        {
             _context = context;
        }

        public Tarif GetTarif(int id)
        {
            return _context.Tarifs.Where(tar => tar.IDTarif == id).FirstOrDefault();
        }

        public ICollection<Tarif> GetTarifs()
        {
            return _context.Tarifs.ToList();
        }

        public bool TarifExists(int id)
        {
            return _context.Tarifs.Any(tar => tar.IDTarif == id);
        }
    }
}
