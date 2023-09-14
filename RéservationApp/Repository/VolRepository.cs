using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class VolRepository : IVolRepository
    {
        private readonly DataContext _context;

        public VolRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateVol(Vol vol)
        {
            _context.Add(vol);
            return Save();
        }

        public Vol GetVol(int id)
        {
            return _context.Vols.Where(v => v.NumVol == id ).FirstOrDefault();
        }

        public Vol GetVolByReservation(int ReservationID)
        {
            return _context.Reservations.Where(res => res.RefReservation == ReservationID).Select(v => v.Vol).FirstOrDefault();
        }

        public ICollection<Vol> GetVols()
        {
            return _context.Vols.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVol(Vol vol)
        {
            _context.Update(vol);
            return Save();
        }

        public bool VolExists(int id)
        {
            return _context.Vols.Any(v => v.NumVol == id);
        }
    }
}
