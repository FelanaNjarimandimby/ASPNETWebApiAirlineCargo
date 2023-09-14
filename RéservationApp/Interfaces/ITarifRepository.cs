using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ITarifRepository
    {
        ICollection<Tarif> GetTarifs();
        Tarif GetTarif(int id);
        bool TarifExists(int id);
    }
}
