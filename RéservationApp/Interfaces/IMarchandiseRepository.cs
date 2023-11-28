using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IMarchandiseRepository
    {
        ICollection<Marchandise> GetMarchandises();
        Marchandise GetMarchandise(int ID);
        ICollection<Nature_Marchandise> GetNatureByMarchandise(int MarchandiseID);
        double GetRapportVolumePoids(int MarchandiseID);
        double GetPoidsTaxation(int MarchandiseID);
        string GetTypeTarif(int MarchandiseID);
        //Récupérer Valeur de cout de fret selon poidTaxation
        string GetValeur(int MarchandiseID);

        //    ICollection<CoutFret> GetCoutByID(int MarchandiseID);

        decimal TarifTotal();
        decimal TarifConfirme();
        decimal TarifReserve();

        ICollection<Marchandise> GetMarchandiseByEtat(string etat);
        ICollection<Marchandise> GetMarchandiseByiDReservation(int id);

        double GetTarifBase(int MarchandiseID);
        double GetTarif(int MarchandiseID);
        bool MarchandiseExists(int ID);
        bool CreateMarchandise(Marchandise marchandise);
        bool UpdateMarchandise(Marchandise marchandise);
        bool Save();
       
    }
}

