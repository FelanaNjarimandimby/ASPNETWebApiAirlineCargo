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

        public bool ClientExists(int ID)
        {
            return _context.Clients.Any(cli => cli.id == ID);   
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

        public Client GetClient(int ID)
        {
            return _context.Clients.Where(cli => cli.id == ID).FirstOrDefault();
        }

        public Client GetClient(string nom)
        {
            return _context.Clients.Where(cli => cli.ClientNom == nom).FirstOrDefault();
        }


        public Client GetClientMail(string mail)
        {
            return _context.Clients.FirstOrDefault(c => c.ClientMail == mail);
        }

        public decimal GetClientReservation(int ID)
        {
            var reservation = _context.Reservations.Where(cli => cli.Client.id == ID);

            if (reservation.Count() <= 0)
                return 0;

            return (decimal)reservation.Sum(r => r.id) / reservation.Count();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(cli => cli.ClientNom).ToList();
        }

        public int GetNombreReservationByClient(int ID)
        {
            var reservation = _context.Reservations.Where(res => res.Client.id == ID);

            if (reservation.Count() <= 0)
                return 0;

            return (int)reservation.Count();
        }

        public ICollection<Reservation> GetReservations(int ID)
        {
            return _context.Reservations.Where(res => res.Client.id == ID).OrderBy(res => res.id).ToList();
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
