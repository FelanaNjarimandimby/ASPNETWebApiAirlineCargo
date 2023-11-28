using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IReservationClientRepository
    {
        ICollection<Reservation> GetReservations();
        Reservation GetReservation(int ReservationID);
        ICollection<Reservation> GetReservationByID(int ID);
        ICollection<Reservation> GetReservationsofClient(int ID);
        decimal GetTarifReservation(int ReservationID);
        bool ReservationExists(int ID);
        bool CreateReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool Save();
    }
}
