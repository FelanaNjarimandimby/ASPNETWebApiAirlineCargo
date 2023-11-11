using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;
        public ReservationRepository(DataContext context)
        {
             _context = context;
        }

        public Reservation GetReservation(int ReservationID)
        {
            return _context.Reservations.Include(res => res.Client).Include(res => res.Marchandise).
                Include(res => res.VolCargo).Include(res => res.Itineraire)
                .Where(res => res.id == ReservationID).FirstOrDefault();
        }

        public bool CreateReservation(Reservation reservation)
        {
            _context.Add(reservation);
            return Save();
        }

        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.Include(res => res.Client).Include(res => res.Marchandise).
                Include(res => res.VolCargo).Include(res => res.Itineraire).ToList();
        }

        public ICollection<Reservation> GetReservationsofClient(int ID)
        {
            return _context.Reservations.Include(res => res.Client).Include(res => res.Marchandise).
                Include(res => res.VolCargo).Include(res => res.Itineraire).Where(res => res.Client.id == ID).ToList();
        }

        public decimal GetTarifReservation(int ReservationID)
        {
            throw new NotImplementedException();
        }

        public bool ReservationExists(int ID)
        {
            return _context.Reservations.Any(res => res.id == ID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReservation(Reservation reservation)
        {
            _context.Update(reservation);
            return Save();
        }

        public bool DeleteReservation(Reservation reservation)
        {
            _context.Remove(reservation);
            return Save();
        }

        public Reservation GetReservationByClient(int ID)
        {
            return _context.Reservations.Include(res => res.Client).Include(res => res.Marchandise).
                Include(res => res.VolCargo).Include(res => res.Itineraire)
                .Where(res => res.Client.id == ID).FirstOrDefault();
        }
    }
}
