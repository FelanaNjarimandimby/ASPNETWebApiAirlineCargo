using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ITypeTarifRepository
    {
        ICollection<TypeTarif> GetTypeTarifs();
        TypeTarif GetTypeTarif(int ID);
        TypeTarif GetTypeTarif(string tarifLibelle);
        bool TypeTarifExists(int ID);
        bool CreateTypeTarif(TypeTarif typeTarif);
        bool UpdateTypeTarif(TypeTarif typeTarif);
        bool DeleteTypeTarif(TypeTarif typeTarif);
        bool Save();
    }
}
