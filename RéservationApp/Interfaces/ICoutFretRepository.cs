using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface ICoutFretRepository
    {
        ICollection<CoutFret> GetCoutFrets();
        CoutFret GetCoutFret(double Poids);
    }
}
