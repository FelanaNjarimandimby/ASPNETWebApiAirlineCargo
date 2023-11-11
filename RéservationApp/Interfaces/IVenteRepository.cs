using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IVenteRepository
    {
        ICollection<Vente> GetVentes();
        Vente GetVente(int VenteID);
        bool CreateVente(Vente vente);
        bool UpdateVente(Vente vente);
        bool DeleteVente(Vente vente);
        bool VenteExists(int ID);
        bool Save();
    }
}
