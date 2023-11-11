using RéservationApp.Models;

namespace RéservationApp.Interfaces
{
    public interface IAgentRepository
    {
        ICollection<Agent> GetAgents();
        Agent GetAgent(int ID);
        Agent GetAgentMail(string mail);
        bool AgentExists(int ID);
        bool CreateAgent(Agent agent);
        bool UpdateAgent(Agent agent);
        bool DeleteAgent(Agent agent);
        bool Save();
    }
}
