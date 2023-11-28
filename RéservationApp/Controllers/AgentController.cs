using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Helper;
using RéservationApp.Interfaces;
using RéservationApp.Migrations;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        private readonly DataContext _context;

        public AgentController(IAgentRepository agentRepository, IMapper mapper, JwtService jwtService, DataContext context) 
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Agent>))]

        public IActionResult IAgents()
        {
            var agents = _mapper.Map<List<AgentDto>>(_agentRepository.GetAgents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(agents);
        }

        [HttpGet("{agentID}")]
        [ProducesResponseType(200, Type = typeof(Agent))]
        [ProducesResponseType(400)]

        public IActionResult GetAgent(int agentID)
        {
            if (!_agentRepository.AgentExists(agentID))
                return NotFound();

            var agent = _mapper.Map<AgentDto>(_agentRepository.GetAgent(agentID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(agent);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateAgent([FromBody] AgentDto agentDto)
        {
            if (agentDto == null)
                return BadRequest(ModelState);

            var agentMail = _agentRepository.GetAgentMail(agentDto.AgentMail);

            var agent = _agentRepository.GetAgents()
                .Where(a => a.AgentNom == agentDto.AgentNom && a.AgentPrenom == agentDto.AgentPrenom
                && a.AgentGenre == agentDto.AgentGenre && a.AgentAdresse == agentDto.AgentAdresse
                && a.AgentContact == agentDto.AgentContact && a.AgentFonction == agentDto.AgentFonction
                && a.AgentMail == agentDto.AgentMail)
                .FirstOrDefault();

            if ((agent != null)  || (agentMail != null))
            {
                ModelState.AddModelError("", "Agent existe déjà");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agentMap = _mapper.Map<Agent>(agentDto);

            if (!_agentRepository.CreateAgent(agentMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Agent ajouté avec succès");

        }

        [HttpPost("login")]
        public IActionResult Login(AgentLoginDto agentLoginDto)
        {
            var agent = _agentRepository.GetAgentMail(agentLoginDto.AgentMail);

            if (agent == null)
                return BadRequest(new { message = "Invalid Credentials" });

            if (!(agentLoginDto.AgentMotPasse == agent.AgentMotPasse))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(agent.id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
                //SameSite = SameSiteMode.None
            });

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("agent")]
        public IActionResult Agent()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var agent = _mapper.Map<AgentDto>(_agentRepository.GetAgent(userId));

                return Ok(agent);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

             return Ok(new
             {
                 message = "success"
             });
        }


        [HttpPut("{agentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateAgent(int agentID, [FromBody] AgentDto updatedAgent)
        {
            if (updatedAgent == null)
                return BadRequest(ModelState);

            if (agentID != updatedAgent.id)
                return BadRequest(ModelState);

            if (!_agentRepository.AgentExists(agentID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var agent = _agentRepository.GetAgents().Where(a => a.id == agentID).FirstOrDefault();
            if (agent != null)
            {
                agent.AgentNom = updatedAgent.AgentNom;
                agent.AgentPrenom = updatedAgent.AgentPrenom;
                agent.AgentGenre = updatedAgent.AgentGenre;
                agent.AgentMail = updatedAgent.AgentMail;
                agent.AgentAdresse = updatedAgent.AgentAdresse;
                agent.AgentContact = updatedAgent.AgentContact;
                agent.AgentFonction = updatedAgent.AgentFonction;
                agent.AgentMotPasse = agent.AgentMotPasse;

                _context.SaveChanges();
            }

            return Ok("Modification de l'agent avec succès");
        }

        [HttpPut("Modifier/{agentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateAgentWithMdP(int agentID, [FromBody] AgentDto updatedAgent)
        {
            if (updatedAgent == null)
                return BadRequest(ModelState);

            if (agentID != updatedAgent.id)
                return BadRequest(ModelState);

            if (!_agentRepository.AgentExists(agentID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var agent = _agentRepository.GetAgents().Where(a => a.id == agentID).FirstOrDefault();
            if (agent != null)
            {
                agent.AgentNom = updatedAgent.AgentNom;
                agent.AgentPrenom = updatedAgent.AgentPrenom;
                agent.AgentGenre = updatedAgent.AgentGenre;
                agent.AgentMail = updatedAgent.AgentMail;
                agent.AgentAdresse = updatedAgent.AgentAdresse;
                agent.AgentContact = updatedAgent.AgentContact;
                agent.AgentFonction = updatedAgent.AgentFonction;
                agent.AgentMotPasse = updatedAgent.AgentMotPasse;

                _context.SaveChanges();
            }

            return Ok("Modification de l'agent avec succès");
        }


        [HttpDelete("{agentID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteAgent(int agentID)
        {
            if (!_agentRepository.AgentExists(agentID))
            {
                return NotFound();
            }

            var agentDelete = _agentRepository.GetAgent(agentID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_agentRepository.DeleteAgent(agentDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Agent supprimé avec succès");
        }
    }
}
