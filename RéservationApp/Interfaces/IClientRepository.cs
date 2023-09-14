using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        Client GetClient(string nom);
        decimal GetClientReservation(int FindID);
        bool ClientExists(int FindID);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);  
        bool Save();
    }
}
