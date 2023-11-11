using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IAeroportRepository
    {
        ICollection<Aeroport> GetAeroports();
        Aeroport GetAeroportID(int ID);
        bool AeroportExists(int ID);
        bool CreateAeroport(Aeroport aeroport);
        bool UpdateAeroport(Aeroport aeroport);
        bool DeleteAeroport(Aeroport aeroport);
        bool Save();
    }
}
