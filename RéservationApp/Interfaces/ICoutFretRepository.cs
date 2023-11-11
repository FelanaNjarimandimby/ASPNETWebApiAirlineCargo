using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ICoutFretRepository
    {
        ICollection<CoutFret> GetCoutFrets();
        CoutFret GetCoutFret(double Poids);
        CoutFret GetCoutFretID(int ID);
        bool CoutFretExists(int ID);
        bool CreateCoutFret(CoutFret coutFret);
        bool UpdateCoutFret(CoutFret coutFret);
        bool DeleteCoutFret(CoutFret coutFret);
        bool Save();
    }
}
