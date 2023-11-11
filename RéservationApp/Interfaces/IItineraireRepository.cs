using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IItineraireRepository
    {
        ICollection<Itineraire> GetItineraires();
        ICollection<Itineraire> GetItinerairesInVol();
        ICollection<Itineraire> GetSpecificItineraire(string depart);
        Itineraire GetItineraire(int ID);
        Itineraire GetItineraire(string depart, string arrive);
        bool ItineraireExists(int ID);
        bool CreateItineraire(Itineraire itineraire);
        bool UpdateItineraire(Itineraire itineraire);
        bool DeleteItineraire(Itineraire itineraire);
        bool Save();
    }
}
