using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController : Controller
    {
        private readonly IVenteRepository _venteRepository;
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IAgentRepository _agentRepository;

        public VenteController(IVenteRepository venteRepository, 
            IMapper mapper,
            IReservationRepository reservationRepository,
            IAgentRepository agentRepository)
        {
            _venteRepository = venteRepository;    
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _agentRepository = agentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vente>))]
        
        public IActionResult GetVentes()
        {
            var ventes = _mapper.Map<List<VenteCargoDto>>(_venteRepository.GetVentes());

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(ventes);
        }

        [HttpGet("{venteID}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Vente>))]
        [ProducesResponseType(400)]

        public IActionResult GetVente(int venteID)
        {
            if (!_venteRepository.VenteExists(venteID))
                return NotFound();

            var vente = _mapper.Map<VenteDto>(_venteRepository.GetVente(venteID));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vente);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateVente([FromBody] VenteDto venteDto)
        {
            if (venteDto == null)
                return BadRequest(ModelState);

            var vente = _venteRepository.GetVentes()
                .Where(v => v.Reservation.id == venteDto.ReservationID)
                .FirstOrDefault();

            if (vente != null)
            {
                ModelState.AddModelError("", "Vente déjà! enregistrée");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venteMap = _mapper.Map<Vente>(venteDto);


            venteMap.Reservation = _reservationRepository.GetReservation(venteDto.ReservationID);
            if (venteMap.Reservation == null)
            {
                ModelState.AddModelError("", "Cette réservation n'existe pas!");
                return StatusCode(422, ModelState);
            }

            venteMap.Agent = _agentRepository.GetAgent(venteDto.AgentID);
            if (venteMap.Agent == null)
            {
                ModelState.AddModelError("", "Cet agent n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_venteRepository.CreateVente(venteMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Vente ajoutée avec succès");
        }

        [HttpPut("{venteID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateVente(int venteID, [FromBody] VenteDto updatedVente)
        {
            if (updatedVente == null)
                return BadRequest(ModelState);

            if (venteID != updatedVente.id)
                return BadRequest(ModelState);

            if (!_venteRepository.VenteExists(venteID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var venteMap = _mapper.Map<Vente>(updatedVente);
            if (!_venteRepository.UpdateVente(venteMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de la vente avec succès");
        }

        [HttpDelete("{venteID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteVente(int venteID)
        {
            if (!_venteRepository.VenteExists(venteID))
                    return NotFound();

            var venteDelete = _venteRepository.GetVente(venteID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_venteRepository.DeleteVente(venteDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Vente supprimée avec succès");
        }

    }
}
