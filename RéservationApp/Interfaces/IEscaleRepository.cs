using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IEscaleRepository
    {
        ICollection<Escale> GetEscales();
        Escale GetEscaleID(int ID);
        bool EscaleExists(int ID);
        bool CreateEscale(Escale escale);
        bool UpdateEscale(Escale escale);
        bool DeleteEscale(Escale escale);
        bool Save();
    }
}
