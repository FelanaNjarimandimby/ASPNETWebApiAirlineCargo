using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IExempleRepository
    {
        ICollection<Exemple> GetExemples();
        bool ExempleExists(int FindID);
        bool CreateExemple(Exemple exemple);
        bool Save();
    }
}
