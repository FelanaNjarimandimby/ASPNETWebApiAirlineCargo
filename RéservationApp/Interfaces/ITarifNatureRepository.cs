using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ITarifNatureRepository
    {
        bool CreateTarifNature(TarifNature tarifNature);
        bool Save();
    }
}
