using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetReservations();
        Reservation GetReservation(int idReservation);
        ICollection<Reservation> GetReservationsofClient(int id);
        bool ReservationExists(int idReservation);
        bool CreateReservation (Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool Save();
    }
}
