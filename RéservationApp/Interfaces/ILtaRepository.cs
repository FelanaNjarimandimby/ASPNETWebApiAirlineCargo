using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ILtaRepository
    {
        ICollection<LTA> GetLtas();
        LTA GetLta(int id);
        bool LtaExists(int LtaID); 
        bool CreateLta(LTA lta);
        bool Save();
    }
}
