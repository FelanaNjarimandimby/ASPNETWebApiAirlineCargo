using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IMarchandiseRepository
    {
        ICollection<Marchandise> GetMarchandises();
        Marchandise GetMarchandise(int id);
        ICollection<Nature_Marchandise> GetNatureByMarchandise(int MarchandiseID);
        double GetRapportVolumePoids(int IDMarchandise);
        double GetPoidsTaxation(int IDMarchandise);
        string GetTypeTarif(int IDMarchandise);
        //Récupérer Valeur de cout de fret selon poidTaxation
        string GetValeur(int IDMarchandise);

    //    ICollection<CoutFret> GetCoutByID(int MarchandiseID);

        double GetTarifBase(int IDMarchandise);

        bool MarchandiseExists(int id);
        bool CreateMarchandise(Marchandise marchandise);
        bool UpdateMarchandise(Marchandise marchandise);
        bool Save();

    }
}

