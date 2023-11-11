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
    public class ItineraireController : Controller
    {
        private readonly IItineraireRepository _itineraireRepository;
        private readonly IMapper _mapper;

        public ItineraireController(IItineraireRepository itineraireRepository, IMapper mapper) 
        {
            _itineraireRepository = itineraireRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Itineraire>))]

        public IActionResult Itineraires()
        {
            var itineraires = _mapper.Map<List<ItineraireDto>>(_itineraireRepository.GetItineraires());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(itineraires);
        }


        [HttpGet("itineraire")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Itineraire>))]

        public IActionResult ItineraireByVol()
        {
            var itineraires = _mapper.Map<List<ItineraireDto>>(_itineraireRepository.GetItinerairesInVol());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(itineraires);
        }

        [HttpGet("itineraireDepart")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Itineraire>))]

        public IActionResult ItineraireDepart()
        {
            var itineraires = _mapper.Map<List<ItineraireDto>>(_itineraireRepository.GetItineraires());
            var depart= itineraires.Select(e => e.ItineraireDepart).Distinct().ToList();   

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(depart);
        }


        [HttpGet("itineraireArrive")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Itineraire>))]

        public IActionResult ItineraireArrive(string depart)
        {
            var itineraires = _mapper.Map<List<ItineraireDto>>(_itineraireRepository.GetSpecificItineraire(depart));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(itineraires);
        }

        [HttpGet("{ItineraireID}")]
        [ProducesResponseType(200, Type = typeof(Itineraire))]
        [ProducesResponseType(400)]

        public IActionResult GetItineraire(int ItineraireID)
        {
            if (!_itineraireRepository.ItineraireExists(ItineraireID))
                return NotFound();

            var itineraire = _mapper.Map<ItineraireDto>(_itineraireRepository.GetItineraire(ItineraireID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(itineraire);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateItineraire([FromBody] ItineraireDto itineraireDto)
        {
            if (itineraireDto == null)
                return BadRequest(ModelState);

            var itineraire = _itineraireRepository.GetItineraires()
                .Where(i => i.ItineraireDepart.Trim().ToUpper() == itineraireDto.ItineraireDepart.TrimEnd().ToUpper()
                && i.ItineraireArrive.Trim().ToUpper() == itineraireDto.ItineraireArrive.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (itineraire != null)
            {
                ModelState.AddModelError("", "Itineraire existe déjà");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itineraireMap = _mapper.Map<Itineraire>(itineraireDto);

            if (!_itineraireRepository.CreateItineraire(itineraireMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Itineraire ajouté avec succès");

        }

        [HttpPut("{itineraireID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateItineraire(int itineraireID, [FromBody] ItineraireDto updatedItineraire)
        {
            if (updatedItineraire == null)
                return BadRequest(ModelState);

            if (itineraireID != updatedItineraire.id)
                return BadRequest(ModelState);

            if (!_itineraireRepository.ItineraireExists(itineraireID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var typeTarifMap = _mapper.Map<Itineraire>(updatedItineraire);
            if (!_itineraireRepository.UpdateItineraire(typeTarifMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de l'itineraire avec succès");
        }

        [HttpDelete("{itineraireID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteTarif(int itineraireID)
        {
            if (!_itineraireRepository.ItineraireExists(itineraireID))
            {
                return NotFound();
            }

            var itineraireDelete = _itineraireRepository.GetItineraire(itineraireID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_itineraireRepository.DeleteItineraire(itineraireDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Itineraire supprimé avec succès");
        }
    }
}
