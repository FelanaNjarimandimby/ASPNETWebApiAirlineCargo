using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class VolCargoRepository : IVolCargoRepository
    {
        private readonly DataContext _context;

        public VolCargoRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVol(VolCargo vol)
        {
            _context.Add(vol);
            return Save();
        }

        public VolCargo GetVolCargo(int VolID)
        {
            return _context.VolCargos.Include(v => v.AvionCargo).Include(v => v.Aeroport).Include(v => v.Itineraire).Where(v => v.id == VolID ).FirstOrDefault();
        }

        public VolCargo GetVolByReservation(int ReservationID)
        {
            return _context.Reservations.Where(res => res.id == ReservationID).Select(v => v.VolCargo).FirstOrDefault();
        }

        public ICollection<VolCargo> GetVolCargos()
        {
            return _context.VolCargos.Include(v => v.AvionCargo).Include(v => v.Aeroport).Include(v => v.Itineraire).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVol(VolCargo vol)
        {
            _context.Update(vol);
            return Save();
        }

        public bool VolExists(int ID)
        {
            return _context.VolCargos.Any(v => v.id == ID);
        }

        public bool DeleteVol(VolCargo vol)
        {
            _context.Remove(vol);
            return Save();
        }

        public VolCargo GetVolByItineraire(string itineraireDepart, string itineraireAarrive)
        {
            return _context.VolCargos.Where(v => v.Itineraire.ItineraireDepart == itineraireDepart && v.Itineraire.ItineraireArrive == itineraireAarrive).FirstOrDefault();
        }

        public VolCargo GetVolByItineraire(int itineraireID)
        {
            return _context.VolCargos.Where(v => v.Itineraire.id == itineraireID).FirstOrDefault();
        }
    }
}
