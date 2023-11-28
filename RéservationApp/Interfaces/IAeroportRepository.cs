using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IAeroportRepository
    {
        ICollection<Aeroport> GetAeroports();
        Aeroport GetAeroportID(int ID);
        Aeroport GetAeroport(string codeiata, string codeoaci, string nom);
        Aeroport GetSpecificAeroport(string codeiata);
        bool AeroportExists(int ID);
        bool CreateAeroport(Aeroport aeroport);
        bool UpdateAeroport(Aeroport aeroport);
        bool DeleteAeroport(Aeroport aeroport);
        bool Save();
    }
}
