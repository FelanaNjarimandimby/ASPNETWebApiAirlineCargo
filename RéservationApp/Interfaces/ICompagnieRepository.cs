using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ICompagnieRepository
    {
        ICollection<Compagnie> GetCompagnies();
        Compagnie GetCompagnie(int ID);
        bool CompagnieExists(int ID);
        bool CreateCompagnie(Compagnie compagnie);
        bool UpdateCompagnie(Compagnie compagnie);
        bool DeleteCompagnie(Compagnie compagnie);
        bool Save();
    }
}
