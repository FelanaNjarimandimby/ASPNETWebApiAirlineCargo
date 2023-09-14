using AutoMapper;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class Nature_MarchandiseRepository : INature_MarchandiseRepository
    {
        private readonly DataContext _context;

        public Nature_MarchandiseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNature_Marchandise(Nature_Marchandise nature_marchandise)
        {
            _context.Add(nature_marchandise);
            return Save();
        }

        public ICollection<Marchandise> GetMarchandiseFromNature(int natureID)
        {
            return _context.Marchandises.Where(nat => nat.Nature_Marchandise.IDNatureMarchandise == natureID).ToList();
        }

        public Nature_Marchandise GetNature_Marchandise(int id)
        {
            return _context.Nature_Marchandises.Where(nat => nat.IDNatureMarchandise == id).FirstOrDefault();
        }

        public Nature_Marchandise GetNature_MarchandiseByMarchandise(int MarchandiseID)
        {
            return _context.Marchandises.Where(mar => mar.IDMarchandise == MarchandiseID).Select(nat => nat.Nature_Marchandise).FirstOrDefault();
        }

        public ICollection<Nature_Marchandise> GetNature_Marchandises()
        {
            return _context.Nature_Marchandises.ToList();
        }

        public bool Nature_MarchandiseExists(int id)
        {
            return _context.Nature_Marchandises.Any(n => n.IDNatureMarchandise == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNature_Marchandise(Nature_Marchandise nature_marchandise)
        {
            _context.Update(nature_marchandise);
            return Save(); 
        }
    }
}
