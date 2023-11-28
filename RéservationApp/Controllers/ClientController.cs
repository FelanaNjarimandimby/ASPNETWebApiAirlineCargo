using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Helper;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly JwtService _jwtService;
        private readonly DataContext _context;

        public ClientController(IClientRepository clientRepository,
            IReservationRepository reservationRepository,
            IMapper mapper,
            JwtService jwtService,
            DataContext context)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _jwtService = jwtService;
            _context = context;
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

        [HttpGet("{ClientID}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]

        public IActionResult GetClient(int ClientID)
        {
            if (!_clientRepository.ClientExists(ClientID))
                return NotFound();

            var client = _mapper.Map<ClientDto>(_clientRepository.GetClient(ClientID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }

        [HttpGet("reservation/{ClientID}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]

        public IActionResult GetReservations(int ClientID)
        {

            if (!_clientRepository.ClientExists(ClientID))
                if (!_reservationRepository.ReservationExists(ClientID))
                    return NotFound();

            var reservations = _mapper.Map<List<ReservationDto>>(_clientRepository.GetReservations(ClientID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("nombre_reservation/{ClientID}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]

        public IActionResult GetNombreReservationByClient(int ClientID)
        {
            if (!_clientRepository.ClientExists(ClientID))
                return NotFound();

            var reservation = _clientRepository.GetNombreReservationByClient(ClientID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservation);
        }

        [HttpGet("{ClientID}/reservation")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetClientReservation(int ClientID)
        {
            if (!_clientRepository.ClientExists(ClientID))
                return NotFound();

            var reservation = _clientRepository.GetClientReservation(ClientID);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reservation);
        }

        [HttpGet("ClientConfirme")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetCLT(string etat)
        {
            var client = _clientRepository.GetClientByEtat(etat);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            var client = new Client
            {
                ClientNom = clientDto.ClientNom,
                ClientPrenom = clientDto.ClientPrenom,
                ClientMail = clientDto.ClientMail,
                ClientAdresse = clientDto.ClientAdresse,
                ClientContact = clientDto.ClientContact,
                ClientMotPasse = clientDto.ClientMotPasse,
            };
            _clientRepository.CreateClient(client);

            return Ok("Client ajouté avec succès");

        }

        [HttpPost("login")]
        public IActionResult Login(ClientLoginDto clientLoginDto)
        {
            var client = _clientRepository.GetClientMail(clientLoginDto.ClientMail);

            if (client == null)
                return BadRequest(new { message = "Invalid Credentials" });

            if (!(clientLoginDto.ClientMotPasse == client.ClientMotPasse))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(client.id);

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

        [HttpGet("client")]
        public IActionResult Client()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var client = _mapper.Map<ClientDto>(_clientRepository.GetClient(userId));

                return Ok(client);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int userId = int.Parse(token.Issuer);

            string cookieKey = $"jwt_{userId}";

            Response.Cookies.Delete(cookieKey);

            return Ok(new
            {
                message = "success"
            });
        }


        [HttpPut("{clientID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateClient(int clientID, [FromBody] ClientDto updatedClient)
        {
            if (updatedClient == null)
                return BadRequest(ModelState);

            if (clientID != updatedClient.id)
                return BadRequest(ModelState);

            if (!_clientRepository.ClientExists(clientID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var client = _clientRepository.GetClients().Where(
            c => c.id == clientID).FirstOrDefault();

            if(client != null)
            {
                client.ClientNom = updatedClient.ClientNom;
                client.ClientPrenom = updatedClient.ClientPrenom;
                client.ClientMail = updatedClient.ClientMail;
                client.ClientAdresse = updatedClient.ClientAdresse;
                client.ClientContact = updatedClient.ClientContact;
                client.ClientMotPasse = client.ClientMotPasse;

                _context.SaveChanges();

            };

            return Ok("Modification du client avec succès");
        }

        [HttpPut("Modifier/{clientID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateClientWithMdP(int clientID, [FromBody] ClientDto updatedClient)
        {
            if (updatedClient == null)
                return BadRequest(ModelState);

            if (clientID != updatedClient.id)
                return BadRequest(ModelState);

            if (!_clientRepository.ClientExists(clientID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var client = _clientRepository.GetClients().Where(
            c => c.id == clientID).FirstOrDefault();

            if (client != null)
            {
                client.ClientNom = updatedClient.ClientNom;
                client.ClientPrenom = updatedClient.ClientPrenom;
                client.ClientMail = updatedClient.ClientMail;
                client.ClientAdresse = updatedClient.ClientAdresse;
                client.ClientContact = updatedClient.ClientContact;
                client.ClientMotPasse = updatedClient.ClientMotPasse;

                _context.SaveChanges();

            };

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
