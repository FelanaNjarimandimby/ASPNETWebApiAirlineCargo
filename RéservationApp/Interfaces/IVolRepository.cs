using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IVolRepository
    {
        ICollection<Vol> GetVols();
        Vol GetVol(int id);
        Vol GetVolByReservation(int ReservationID);
        bool VolExists(int id);
        bool CreateVol(Vol vol);
        bool UpdateVol(Vol vol);
        bool Save();
    }
}
