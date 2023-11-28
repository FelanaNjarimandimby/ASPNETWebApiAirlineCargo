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
        private readonly ICoutFretRepository _coutFretRepository;
        private readonly ITypeTarifRepository _typeTarifRepository;
        private readonly IReservationRepository _reservationRepository;

        public MarchandiseRepository(DataContext context, 
            INature_MarchandiseRepository nature_MarchandiseRepository,
            ICoutFretRepository coutFretRepository,
            ITypeTarifRepository typeTarifRepository,
            IReservationRepository reservationRepository)
        {
            _context = context;
            _nature_MarchandiseRepository = nature_MarchandiseRepository;
            _coutFretRepository = coutFretRepository;
            _typeTarifRepository = typeTarifRepository;
            _reservationRepository = reservationRepository;
        }

        public bool CreateMarchandise(Marchandise marchandise)
        {
            _context.Add(marchandise);
            return Save();
        }

        public Marchandise GetMarchandise(int ID)
        {
            return _context.Marchandises.Where(mar => mar.id == ID).OrderBy(m => m.id).FirstOrDefault();
        }

        public Marchandise GetMarchandise(double Poids)
        {
            return _context.Marchandises.Where(mar => mar.MarchandisePoids == Poids).FirstOrDefault();
        }

        public ICollection<Marchandise> GetMarchandises()
        {
            return _context.Marchandises.Include(mar => mar.Nature_Marchandise).OrderBy(m => m.id).ToList();
        }

        public double GetPoidsTaxation(int MarchandiseID)
        {
            double poids = 0;

            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.id == MarchandiseID);

            if (marchandise == null)
                return 0;

            double poidsEquivalent = (marchandise.MarchandiseVolume) / 6;
            double poidsReel = marchandise.MarchandisePoids;

            if (poidsEquivalent < poidsReel)
                poids = poidsReel;

            if (poidsEquivalent > poidsReel)
                poids = poidsEquivalent;

            return poids;
        }
        public double GetTarifBase(int MarchandiseID)
        {
            var poidsTaxation = this.GetPoidsTaxation(MarchandiseID);
            var poidsFret = _coutFretRepository.GetCoutFret(poidsTaxation);

            var marchandise = this.GetMarchandises().Where(m => m.id == MarchandiseID).FirstOrDefault();
            var natureID = marchandise.Nature_Marchandise.id;
            var nature = _nature_MarchandiseRepository.GetNature_Marchandises().Where(c => c.id.Equals(natureID)).FirstOrDefault();
            var typeTarifID = nature.TypeTarif.id;
            var typeTarif = _typeTarifRepository.GetTypeTarifs().Where(t => t.id == typeTarifID).FirstOrDefault();
            var valeur = typeTarif.TarifValeur;

            var tarifBase = (poidsFret.Cout * poidsTaxation *  valeur)/100;

            return tarifBase;
        }
        public double GetTarif(int MarchandiseID)
        {
            var tarifBase = this.GetTarifBase(MarchandiseID);
            var marchandise = this.GetMarchandises().Where(m => m.id == MarchandiseID).FirstOrDefault();
            var natureID = marchandise.Nature_Marchandise.id;
            var nature = _nature_MarchandiseRepository.GetNature_Marchandises().Where(c => c.id.Equals(natureID)).FirstOrDefault();
            var typeTarifID = nature.TypeTarif.id;
            var typeTarif = _typeTarifRepository.GetTypeTarifs().Where(t => t.id == typeTarifID).FirstOrDefault();
            var fraisAssurance = typeTarif.TarifFraisAssurance;
            var fraisAnnexe = typeTarif.TarifAnnexe;
            var tarif = tarifBase + fraisAssurance + fraisAnnexe;

            return tarif;
        }

        public double GetRapportVolumePoids(int MarchandiseID)
        {
            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.id == MarchandiseID);

            if (marchandise == null)
                return 0;

            var volume = (marchandise.MarchandiseVolume);
            var rapportVP = volume / (marchandise.MarchandisePoids);
            return rapportVP;
        }

        public string GetTypeTarif(int MarchandiseID)
        {
            string typeTarif = "";
            
            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.id == MarchandiseID);

            if (marchandise == null)
                return "";

           /* var nature = _nature_MarchandiseRepository.GetNature_MarchandiseByMarchandise(MarchandiseID);
            if (nature.NatureMarchandiseID == 2)
                typeTarif = "Tarifs généraux";

            if (nature.NatureMarchandiseID == 1)
                typeTarif = "Tarifs de classification";

            if (nature.NatureMarchandiseID == 1)
                typeTarif = "Tarifs spéciaux";*/

            return typeTarif;
        }

        public bool MarchandiseExists(int ID)
        {
            return _context.Marchandises.Any(mar => mar.id == ID);
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

        

        public string GetValeur(int MarchandiseID)
        {

            var marchandise = _context.Marchandises.FirstOrDefault(mar => mar.id == MarchandiseID);

            if (marchandise == null)
                return "";

            var coutFrets = _context.CoutFrets.FirstOrDefault();
            //var valeur = IMarchandiseRepository.GetNatureByMarchandise(IDMarchandise);

            var poidsMin = coutFrets.CoutPoidsMin;
            var poidsMax = coutFrets.CoutPoidsMax;
            var poidsTaxation = GetPoidsTaxation(marchandise.id);

            return "";


            //var coutFrets = _coutFretRepository.GetCoutFrets();

        }

        public ICollection<Nature_Marchandise> GetNatureByMarchandise(int MarchandiseID)
        {
            return _context.Marchandises.Where(mar => mar.id == MarchandiseID).Select(n => n.Nature_Marchandise).ToList();   
        }

        public decimal TarifTotal()
        {
            var marchandisesIds = GetMarchandises().Select(m => m.id).ToList();

            if (marchandisesIds == null || marchandisesIds.Count == 0)
            {
                return 0;
            }

            decimal totalTarif = 0;

            foreach (var marchandiseId in marchandisesIds)
            {
                // Faites quelque chose avec marchandiseId, par exemple, imprimez-le
                Console.WriteLine(GetTarif(marchandiseId));

                // Ajoutez le tarif au total
                totalTarif += (decimal)(GetTarif(marchandiseId));
            }

            return totalTarif;
        }

        public ICollection<Marchandise> GetMarchandiseByEtat(string etat)
        {
            
            var marchandise = _context.Reservations.Where(r => r.ReservationEtat == etat).Include(r => r.Marchandise).Select(o => o.Marchandise).ToList();

            return marchandise;
        }

        public decimal TarifConfirme()
        {
            var marchandisesIds = GetMarchandiseByEtat("Confirmé").Select(m => m.id).ToList();

            if (marchandisesIds == null || marchandisesIds.Count == 0)
            {
                return 0;
            }

            decimal totalTarif = 0;

            foreach (var marchandiseId in marchandisesIds)
            {
                // Faites quelque chose avec marchandiseId, par exemple, imprimez-le
                Console.WriteLine(GetTarif(marchandiseId));

                // Ajoutez le tarif au total
                totalTarif += (decimal)(GetTarif(marchandiseId));
            }

            return totalTarif;
        }

        public decimal TarifReserve()
        {
            var marchandisesIds = GetMarchandiseByEtat("Reservé").Select(m => m.id).ToList();

            if (marchandisesIds == null || marchandisesIds.Count == 0)
            {
                return 0;
            }

            decimal totalTarif = 0;

            foreach (var marchandiseId in marchandisesIds)
            {
                // Faites quelque chose avec marchandiseId, par exemple, imprimez-le
                Console.WriteLine(GetTarif(marchandiseId));

                // Ajoutez le tarif au total
                totalTarif += (decimal)(GetTarif(marchandiseId));
            }

            return totalTarif;
        }

        public ICollection<Marchandise> GetMarchandiseByiDReservation(int id)
        {
            var marchandise = _context.Reservations.Where(r => r.id == id).Include(r => r.Marchandise).Select(o => o.Marchandise).ToList();

            return marchandise;
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
