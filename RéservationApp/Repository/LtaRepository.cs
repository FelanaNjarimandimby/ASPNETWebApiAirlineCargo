using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class LtaRepository : ILtaRepository
    {
        private readonly DataContext _context;

        public LtaRepository(DataContext context)
        {
             _context = context;
        }

        public bool CreateLta(LTA lta)
        {
            _context.Add(lta);
            return Save();
        }

        public bool DeleteLta(LTA lta)
        {
            _context.Remove(lta);
            return Save();
        }

        public LTA GetLta(int ID)
        {
            return _context.LTAs.Include(l => l.Vente).Include(l => l.Vente.Agent).Include(l => l.Vente.Reservation).
                Include(l => l.Vente.Reservation.Marchandise).Include(l => l.Vente.Reservation.Marchandise).
                Include(l => l.Vente.Reservation.Marchandise.Nature_Marchandise).
                Include(l => l.Vente.Reservation.Marchandise.Nature_Marchandise.TypeTarif).
                Include(l => l.Vente.Reservation.Client).
                Include(l => l.Vente.Reservation.VolCargo).
                Include(l => l.Vente.Reservation.VolCargo.Itineraire).
                Include(l => l.Vente.Reservation.VolCargo.AvionCargo).
                Include(l => l.Vente.Reservation.VolCargo.Aeroport).
                Include(l => l.Vente.Reservation.VolCargo.Aeroport.Compagnie).
                Where(l => l.id == ID).FirstOrDefault();
        }

        public ICollection<LTA> GetLtas()
        {
            return _context.LTAs.Include(l => l.Vente).Include(l => l.Vente.Agent).Include(l => l.Vente.Reservation).
                Include(l => l.Vente.Reservation.Marchandise).Include(l => l.Vente.Reservation.Marchandise).
                Include(l => l.Vente.Reservation.Marchandise.Nature_Marchandise).
                Include(l => l.Vente.Reservation.Marchandise.Nature_Marchandise.TypeTarif).
                Include(l => l.Vente.Reservation.Client).
                Include(l => l.Vente.Reservation.VolCargo).
                Include(l => l.Vente.Reservation.VolCargo.Itineraire).
                Include(l => l.Vente.Reservation.VolCargo.AvionCargo).
                Include(l => l.Vente.Reservation.VolCargo.Aeroport).
                Include(l => l.Vente.Reservation.VolCargo.Aeroport.Compagnie).ToList();
        }

        public bool LtaExists(int ID)
        {
            return _context.LTAs.Any(l => l.id == ID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLta(LTA lta)
        {
            _context.Update(lta);
            return Save();
        }
    }
}
