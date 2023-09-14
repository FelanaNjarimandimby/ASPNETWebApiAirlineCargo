using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public IActionResult GetClients()
        {
            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetClients());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clients);
        }

        [HttpGet("{FindID}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]

        public IActionResult GetClient(int FindID)
        {
            if (!_clientRepository.ClientExists(FindID))
                return NotFound();

            var client = _mapper.Map<ClientDto>(_clientRepository.GetClient(FindID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }

        [HttpGet("{FindID}/reservation")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetClientReservation(int FindID)
        {
            if (!_clientRepository.ClientExists(FindID))
                return NotFound();

            var reservation = _clientRepository.GetClientReservation(FindID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservation);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        
        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
                return BadRequest(ModelState);

            var client = _clientRepository.GetClients()
                .Where(c => c.NomClient.Trim().ToUpper() == clientDto.NomClient.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (client != null)
            {
                ModelState.AddModelError("", "Client existe déjà");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientMap = _mapper.Map<Client>(clientDto);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Client ajouté avec succès");

        }

        [HttpPut("{clientID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateClient(int clientID, [FromBody] ClientDto updatedClient)
        {
            if (updatedClient == null)
                return BadRequest(ModelState);

            if (clientID != updatedClient.IDClient)
                return BadRequest(ModelState);

            if (!_clientRepository.ClientExists(clientID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var clientMap = _mapper.Map<Client>(updatedClient);
            if (!_clientRepository.UpdateClient(clientMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du client avec succès");
        }

        [HttpDelete("{clientID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteClient(int clientID)
        {
            if(!_clientRepository.ClientExists(clientID))
            {
                return NotFound();
            }

            var clientDelete = _clientRepository.GetClient(clientID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_clientRepository.DeleteClient(clientDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Client supprimé avec succès");
        }
    }

}
