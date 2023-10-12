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

        public bool CreateReservation(Reservation reservation)
        {
            _context.Add(reservation);
            return Save();
        }

        public Reservation GetReservation(int idReservation)
        {
            return _context.Reservations.Where(res => res.RefReservation == idReservation).FirstOrDefault();
        }

        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.Include(res => res.Client).Include(res => res.Marchandise).Include(res => res.Vol).ToList();
        }

        public ICollection<Reservation> GetReservationsofClient(int id)
        {
            return _context.Reservations.Where(res => res.Client.IDClient == id).ToList();
        }

        public decimal GetTarifReservation(int IDReservation)
        {
            throw new NotImplementedException();
        }

        public bool ReservationExists(int idReservation)
        {
            return _context.Reservations.Any(res => res.RefReservation == idReservation);
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
    }
}
