using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class ItineraireRepository : IItineraireRepository
    {
        private readonly DataContext _context;
        private readonly IVolCargoRepository _volCargoRepository;

        public ItineraireRepository(DataContext context, IVolCargoRepository volCargoRepository)
        {
            _context = context;
            _volCargoRepository = volCargoRepository;
        }
        public bool CreateItineraire(Itineraire itineraire)
        {
            _context.Add(itineraire);
            return Save(); 
        }

        public bool DeleteItineraire(Itineraire itineraire)
        {
            _context.Remove(itineraire);
            return Save();
        }

        public Itineraire GetItineraire(int ID)
        {
            return _context.Itineraires.Where(i => i.id== ID).FirstOrDefault();
        }

        public Itineraire GetItineraire(string depart, string arrive)
        {
            return _context.Itineraires.Where(i => i.ItineraireDepart == depart && i.ItineraireArrive == arrive).FirstOrDefault();
        }

        public ICollection<Itineraire> GetItineraires()
        {
            return _context.Itineraires.ToList();
        }

        public ICollection<Itineraire> GetItinerairesInVol()
        {
            var vols = _volCargoRepository.GetVolCargos().FirstOrDefault();
            return _context.Itineraires.Where(i => i.id == vols.Itineraire.id).ToList();
        }

        public ICollection<Itineraire> GetSpecificItineraire(string depart)
        {
            return _context.Itineraires.Where(i => i.ItineraireDepart == depart).ToList();
        }

        public bool ItineraireExists(int ID)
        {
            return _context.Itineraires.Any(i => i.id == ID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateItineraire(Itineraire itineraire)
        {
            _context.Update(itineraire);
            return Save();
        }
    }
}
