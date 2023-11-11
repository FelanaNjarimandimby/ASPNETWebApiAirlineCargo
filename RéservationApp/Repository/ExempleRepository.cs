using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class ExempleRepository : IExempleRepository
    {
        private readonly DataContext _context;

        public ExempleRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateExemple(Exemple exemple)
        {
            _context.Add(exemple);
            return Save();
        }

        public bool ExempleExists(int FindID)
        {
            return _context.Exemples.Any(cli => cli.ID == FindID);
        }

        public ICollection<Exemple> GetExemples()
        {

            return _context.Exemples.OrderBy(cli => cli.ID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
