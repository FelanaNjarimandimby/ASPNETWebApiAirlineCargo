using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ILtaRepository
    {
        ICollection<LTA> GetLtas();
        LTA GetLta(int ID);
        bool LtaExists(int ID); 
        bool CreateLta(LTA lta);
        bool UpdateLta(LTA lta);
        bool DeleteLta(LTA lta);
        bool Save();
    }
}
