using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IMarchandiseRepository
    {
        ICollection<Marchandise> GetMarchandises();
        Marchandise GetMarchandise(int id);
        ICollection<Nature_Marchandise> GetNatureByMarchandise(int MarchandiseID);
        bool MarchandiseExists(int id);
        bool CreateMarchandise(Marchandise marchandise);
        bool UpdateMarchandise(Marchandise marchandise);
        bool Save();

    }
}
