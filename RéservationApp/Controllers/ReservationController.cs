using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Data;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRespository;
        private readonly IClientRepository _clientRepository;
        private readonly IMarchandiseRepository _marchandiseRepository;
        private readonly IVolRepository _volRepository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepository,
            IClientRepository clientRepository,
            IMarchandiseRepository marchandiseRepository,
            IVolRepository volRepository,
            IMapper mapper)
        {
            _reservationRespository = reservationRepository;
            _clientRepository = clientRepository;
            _marchandiseRepository = marchandiseRepository;
            _volRepository = volRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        public IActionResult GetReservations()
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationRespository.GetReservations());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("{reservationRef}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservation(int reservationRef)
        {
            if (!_reservationRespository.ReservationExists(reservationRef))
                return NotFound();

            var reservation = _mapper.Map<ReservationDto>(_reservationRespository.GetReservation(reservationRef));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservation);
        }

        [HttpGet("client/{IDClient}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]

        public IActionResult GetReservationsofClient(int IDClient)
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationRespository.GetReservationsofClient(IDClient));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        
        public IActionResult CreateReservation([FromQuery] int clientID, [FromQuery] int marchandiseID, [FromQuery] int volNUM ,[FromBody] ReservationDto reservationCreate)
        {
            if(reservationCreate == null)
                return BadRequest(ModelState);

            var reservation = _reservationRespository.GetReservations()
            .Where(res => res.NomDestinaire.Trim().ToUpper() == reservationCreate.NomDestinaire.TrimEnd().ToUpper())
            .FirstOrDefault();

            if(reservation != null)
            {
                ModelState.AddModelError("", "Réservation existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservationMap = _mapper.Map<Reservation>(reservationCreate);

            reservationMap.Client = _clientRepository.GetClient(clientID);

            if (!_clientRepository.ClientExists(clientID))
            {
                ModelState.AddModelError("", "Ce client existe pas!");
                return StatusCode(422, ModelState);
            }

            reservationMap.Marchandise = _marchandiseRepository.GetMarchandise(marchandiseID);
            
            if(reservationMap.Marchandise == null)
            {
                ModelState.AddModelError("", "Cette marchandise existe pas!");
                return StatusCode(422, ModelState);
            }

            reservationMap.Vol = _volRepository.GetVol(volNUM);
            if(reservationMap.Vol == null)
            {
                ModelState.AddModelError("", "Ce vol existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_reservationRespository.CreateReservation(reservationMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Réservation ajoutée avec succès");
        }

        [HttpPut("{reservationRef}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateReservation(int reservationRef, [FromBody] ReservationDto reservationUpdate)
        {
            if (reservationUpdate == null)
                return BadRequest(ModelState);

            if (reservationRef != reservationUpdate.RefReservation)
                return BadRequest(ModelState);

            if (!_reservationRespository.ReservationExists(reservationRef))
                return NotFound();

            if(!ModelState.IsValid) 
                return BadRequest();

            var reservationMap = _mapper.Map<Reservation>(reservationUpdate);

            if(!_reservationRespository.UpdateReservation(reservationMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de la réservation avec succès");
        }
    }
}

