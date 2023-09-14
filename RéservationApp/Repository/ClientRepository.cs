using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class ClientRepository: IClientRepository
    {
        public readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public bool ClientExists(int FindID)
        {
            return _context.Clients.Any(cli => cli.IDClient == FindID);   
        }

        public bool CreateClient(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public Client GetClient(int id)
        {
            return _context.Clients.Where(cli => cli.IDClient == id).FirstOrDefault();
        }

        public Client GetClient(string nom)
        {
            return _context.Clients.Where(cli => cli.NomClient == nom).FirstOrDefault();
        }

        public decimal GetClientReservation(int FindID)
        {
            var reservation = _context.Reservations.Where(cli => cli.Client.IDClient == FindID);

            if (reservation.Count() <= 0)
                return 0;

            return (decimal)reservation.Sum(r => r.RefReservation) / reservation.Count();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(cli => cli.IDClient).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClient(Client client)
        {
            _context.Update(client);
            return Save();
        }
    }
}
