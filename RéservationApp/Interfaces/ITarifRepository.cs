using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ITarifRepository
    {
        ICollection<Tarif> GetTarifs();
        Tarif GetTarif(int id);
        //bool CreateTarif(int RefReservation);
        bool TarifExists(int id);
    }
}
