using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IVolCargoRepository
    {
        ICollection<VolCargo> GetVolCargos();
        VolCargo GetVolCargo(int VolID);
        VolCargo GetVolByReservation(int ReservationID);
        VolCargo GetVolByItineraire(string itineraireDepart, string itineraireAarrive);
        VolCargo GetVolByItineraire(int itineraireID);
        bool VolExists(int ID);
        bool CreateVol(VolCargo vol);
        bool UpdateVol(VolCargo vol);
        bool DeleteVol(VolCargo vol);
        bool Save();
    }
}
