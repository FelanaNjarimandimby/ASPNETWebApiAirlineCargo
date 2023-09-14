using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IVenteRepository
    {
        ICollection<Vente> GetVentes();
        Vente GetVente(int id);
        bool VenteExists(int venteID);
    }
}
