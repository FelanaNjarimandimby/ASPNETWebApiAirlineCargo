using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        Client GetClient(string nom);
        Client GetClientMail(string mail);
        decimal GetClientReservation(int ID);
        ICollection<Reservation> GetReservations(int ID);
        ICollection<Client> GetClientByEtat(string etat);
        int GetNombreReservationByClient(int ID); 
        bool ClientExists(int ID);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);  
        bool Save();
    }
}
