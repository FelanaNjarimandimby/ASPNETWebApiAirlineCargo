using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IAvionCargoRepository
    {
        ICollection<AvionCargo> GetAvionCargos();
        AvionCargo GetAvion(int ID);
        bool AvionExists(int ID);
        bool CreateAvion(AvionCargo avion);
        bool UpdateAvion(AvionCargo avion);
        bool DeleteAvion(AvionCargo avion);
        bool Save();
    }
}
