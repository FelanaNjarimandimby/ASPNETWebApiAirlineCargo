using RéservationApp.Data;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly DataContext _context;

        public AgentRepository(DataContext context)
        {
            _context = context;
        }

        public bool AgentExists(int ID)
        {
            return _context.Agents.Any(a => a.id == ID);
        }

        public bool CreateAgent(Agent agent)
        {
            _context.Add(agent);
            return Save();
        }

        public bool DeleteAgent(Agent agent)
        {
            _context.Remove(agent);
            return Save();
        }

        public Agent GetAgent(int ID)
        {
            return _context.Agents.Where(a => a.id == ID).FirstOrDefault();
        }

        public Agent GetAgentMail(string mail)
        {
            return _context.Agents.FirstOrDefault(a => a.AgentMail == mail);
        }

        public ICollection<Agent> GetAgents()
        {
            return _context.Agents.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAgent(Agent agent)
        {
            _context.Update(agent);
            return Save();
        }
    }
}
