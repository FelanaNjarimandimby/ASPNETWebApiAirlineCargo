using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class TypeTarifRepository : ITypeTarifRepository
    {
        private readonly DataContext _context;

        public TypeTarifRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateTypeTarif(TypeTarif typeTarif)
        {
            _context.Add(typeTarif);
            return Save(); ;
        }

        public bool DeleteTypeTarif(TypeTarif typeTarif)
        {
            _context.Remove(typeTarif);
            return Save();
        }

        public TypeTarif GetTypeTarif(int ID)
        {
            return _context.TypeTarifs.Where(typ => typ.id == ID).FirstOrDefault();
        }

        public TypeTarif GetTypeTarif(string tarifLibelle)
        {
            return _context.TypeTarifs.Where(typ => typ.TarifLibelle == tarifLibelle).FirstOrDefault();
        }

        public ICollection<TypeTarif> GetTypeTarifs()
        {
            return _context.TypeTarifs.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TypeTarifExists(int ID)
        {
            return _context.TypeTarifs.Any(typ => typ.id == ID);
        }

        public bool UpdateTypeTarif(TypeTarif typeTarif)
        {
            _context.Update(typeTarif);
            return Save();
        }
    }
}
