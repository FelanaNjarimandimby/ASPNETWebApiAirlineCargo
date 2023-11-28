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

        public TypeTarif GetTarifMarchandise(int idMarchandise)
        {
            var natures = _context.Marchandises.Where(mar => mar.id == idMarchandise).Select(nat => nat.Nature_Marchandise).FirstOrDefault();
            var typeTarif = this.GetTypeTarifs().Where(t => t.id == natures.TypeTarif.id).FirstOrDefault();

            //var marchandise = _context.Marchandises.Where(m => m.id == idMarchandise).FirstOrDefault();
            //var natureID = marchandise.;
            //var nature = _context.Nature_Marchandises.Where(c => c.id.Equals(natureID)).FirstOrDefault();
            //var typeTarifID = nature.TypeTarif.id;
            //var typeTarif = this.GetTypeTarifs().Where(t => t.id == typeTarifID).FirstOrDefault();


            
            //var marchandise = _marchandiseRepository.GetMarchandises().Where(m => m.id == idMarchandise).FirstOrDefault();
            //var natureID = marchandise.Nature_Marchandise.id;
            //var nature = _nature_MarchandiseRepository.GetNature_Marchandises().Where(c => c.id.Equals(natureID)).FirstOrDefault();
            //var typeTarifID = nature.TypeTarif.id;
            //var typeTarif = this.GetTypeTarifs().Where(t => t.id == typeTarifID).FirstOrDefault();
            //var fraisAssurance = typeTarif.TarifFraisAssurance;

            return typeTarif;
        }

        public TypeTarif GetTypeTarif(int ID)
        {
            return _context.TypeTarifs.Where(typ => typ.id == ID).OrderBy(t => t.id).FirstOrDefault();
        }

        public TypeTarif GetTypeTarif(string tarifLibelle)
        {
            return _context.TypeTarifs.Where(typ => typ.TarifLibelle == tarifLibelle).OrderBy(t => t.id).FirstOrDefault();
        }

        public ICollection<TypeTarif> GetTypeTarifs()
        {
            return _context.TypeTarifs.OrderBy(t => t.id).ToList();
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
