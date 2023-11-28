using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface INature_MarchandiseRepository
    {
        ICollection<Nature_Marchandise> GetNature_Marchandises();
        
        Nature_Marchandise GetNature_Marchandise(int ID);
        Nature_Marchandise GetNature(string Libelle);
        Nature_Marchandise GetNature_MarchandiseByMarchandise(int MarchandiseID);
        ICollection<Marchandise> GetMarchandiseFromNature(int natureID);
        bool Nature_MarchandiseExists(int ID);
        bool CreateNature_Marchandise(Nature_Marchandise nature_marchandise);
        bool UpdateNature_Marchandise(Nature_Marchandise nature_marchandise);
        bool DeleteNature_Marchandise(Nature_Marchandise nature_marchandise);
        bool Save();
     
    }
}
