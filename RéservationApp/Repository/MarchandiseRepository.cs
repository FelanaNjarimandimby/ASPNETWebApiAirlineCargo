using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class MarchandiseRepository : IMarchandiseRepository
    {
        private DataContext _context;

        public MarchandiseRepository(DataContext context)
        {
            _context = context;   
        }

        public bool CreateMarchandise(Marchandise marchandise)
        {
            _context.Add(marchandise);
            return Save();
        }

        public Marchandise GetMarchandise(int id)
        {
            return _context.Marchandises.Where(mar => mar.IDMarchandise == id).FirstOrDefault();
        }

        public ICollection<Marchandise> GetMarchandises()
        {
            return _context.Marchandises.ToList();
        }

        public bool MarchandiseExists(int id)
        {
            return _context.Marchandises.Any(mar => mar.IDMarchandise == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMarchandise(Marchandise marchandise)
        {
            _context.Update(marchandise);
            return Save();
        }

        ICollection<Nature_Marchandise> IMarchandiseRepository.GetNatureByMarchandise(int MarchandiseID)
        {
            return _context.Marchandises.Where(mar => mar.IDMarchandise == MarchandiseID).Select(n => n.Nature_Marchandise).ToList();
        }
    }
}
