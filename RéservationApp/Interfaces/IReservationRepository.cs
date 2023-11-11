using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetReservations();
        Reservation GetReservation(int ReservationID);
        ICollection<Reservation> GetReservationsofClient(int ID);

        Reservation GetReservationByClient(int ID);
        decimal GetTarifReservation(int ReservationID);
        bool ReservationExists(int ID);
        bool CreateReservation (Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool DeleteReservation(Reservation reservation);
        bool Save(); 
    }
}
