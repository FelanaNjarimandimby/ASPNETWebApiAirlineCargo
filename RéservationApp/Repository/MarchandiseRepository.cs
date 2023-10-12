using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using System.Net.Sockets;

namespace RéservationApp.Repository
{
    public class MarchandiseRepository : IMarchandiseRepository
    {
        private DataContext _context;
        private readonly INature_MarchandiseRepository _nature_MarchandiseRepository;

        public MarchandiseRepository(DataContext context, INature_MarchandiseRepository nature_MarchandiseRepository)
        {
            _context = context;
            _nature_MarchandiseRepository = nature_MarchandiseRepository;
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

        public Marchandise GetMarchandise(double Poids)
        {
            return _context.Marchandises.Where(mar => mar.Poids == Poids).FirstOrDefault();
        }

        public ICollection<Marchandise> GetMarchandises()
        {
            return _context.Marchandises.Include(mar => mar.Nature_Marchandise).ToList();
        }

        public double GetPoidsTaxation(int IDMarchandise)
        {
            double poids = 0;

            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == IDMarchandise);

            if (marchandise == null)
                return 0;

            var marchandise1 = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == IDMarchandise);

            double poidsEquivalent = double.Parse(marchandise1.Volume) / 6;
            double poidsReel = marchandise1.Poids;

            if (poidsEquivalent < poidsReel)
                poids = poidsReel;

            if (poidsEquivalent > poidsReel)
                poids = poidsEquivalent;

            return poids;
        }

        public double GetRapportVolumePoids(int IDMarchandise)
        {
            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == IDMarchandise);

            if (marchandise == null)
                return 0;

            var volume = double.Parse(marchandise.Volume);
            var rapportVP = volume / (marchandise.Poids);
            return rapportVP;
        }

        public string GetTypeTarif(int IDMarchandise)
        {
            string typeTarif = "";
            
            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == IDMarchandise);

            if (marchandise == null)
                return "";

            var nature = _nature_MarchandiseRepository.GetNature_MarchandiseByMarchandise(IDMarchandise);
            if (nature.IDNatureMarchandise == 2)
                typeTarif = "Tarifs généraux";

            if (nature.IDNatureMarchandise == 1)
                typeTarif = "Tarifs de classification";

            if (nature.IDNatureMarchandise == 1)
                typeTarif = "Tarifs spéciaux";

            return typeTarif;
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

        public string GetValeur(int IDMarchandise)
        {

            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == IDMarchandise);

            if (marchandise == null)
                return "";

            var coutFrets = _context.CoutFrets.FirstOrDefault();
            //var valeur = IMarchandiseRepository.GetNatureByMarchandise(IDMarchandise);

            var poidsMin = coutFrets.PoidsMin;
            var poidsMax = coutFrets.PoidsMax;
            var poidsTaxation = GetPoidsTaxation(marchandise.IDMarchandise);

            return "";


            //var coutFrets = _coutFretRepository.GetCoutFrets();

        }

        public double GetTarifBase(int IDMarchandise)
        {
            throw new NotImplementedException();
        }

        /*    public ICollection<CoutFret> GetCoutByID(int MarchandiseID)
            {
                var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.IDMarchandise == MarchandiseID);

                var poidsTaxation = GetPoidsTaxation(marchandise.IDMarchandise);

                var coutFrets = _context.CoutFrets.FirstOrDefault();
                //var valeur = IMarchandiseRepository.GetNatureByMarchandise(IDMarchandise);

                var poidsMin = coutFrets.PoidsMin;
                var poidsMax = coutFrets.PoidsMax;
                for(poidsTaxation in Range[poidsMin,poidsMax])
                {

                }
                return _context.Marchandises.Where(mar => mar.IDMarchandise == MarchandiseID).Select(n => n.Nature_Marchandise).ToList();
            }  */
    }
}
