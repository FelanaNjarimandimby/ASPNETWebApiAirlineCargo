using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class VolCargoController : Controller
    {
        private readonly IVolCargoRepository _volCargoRepository;
        private readonly IMapper _mapper;
        private readonly IAvionCargoRepository _avionCargoRepository;
        private readonly IAeroportRepository _aeroportRepository;
        private readonly IItineraireRepository _itineraireRepository;

        public VolCargoController(IVolCargoRepository volCargoRepository, 
            IMapper mapper,
            IAvionCargoRepository avionCargoRepository,
            IAeroportRepository aeroportRepository,
            IItineraireRepository itineraireRepository)
        {
            _volCargoRepository = volCargoRepository;
            _mapper = mapper;
            _avionCargoRepository = avionCargoRepository;
            _aeroportRepository = aeroportRepository;
            _itineraireRepository = itineraireRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VolCargo>))]

        public IActionResult GetVols()
        {
            var vols = _mapper.Map<List<VolCargoDto>>(_volCargoRepository.GetVolCargos());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vols);
        }

        [HttpGet("reservations/{reservationID}")]
        [ProducesResponseType(200, Type = typeof(VolCargo))]
        [ProducesResponseType(400)]

        public IActionResult GetVolByReservation(int reservationID)
        {
            var vol = _mapper.Map<VolCargoDto>(
                _volCargoRepository.GetVolByReservation(reservationID));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(vol);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateVol([FromBody] VolCargoDto volCreate)
        {
            if (volCreate == null)
                return BadRequest(ModelState);

            var vol = _volCargoRepository.GetVolCargos()
                .Where(v => v.VolNumero == volCreate.VolNumero).FirstOrDefault();

            if (vol != null)
            {
                ModelState.AddModelError("", "Ce vol existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var volMap = _mapper.Map<VolCargo>(volCreate);

            volMap.AvionCargo = _avionCargoRepository.GetAvion(volCreate.AvionID);
            if (volMap.AvionCargo == null)
            {
                ModelState.AddModelError("", "Cet avion n'existe pas!");
                return StatusCode(422, ModelState);
            }

            volMap.Aeroport = _aeroportRepository.GetAeroportID(volCreate.AeroportID);
            if (volMap.Aeroport == null)
            {
                ModelState.AddModelError("", "Cet aéroport n'existe pas!");
                return StatusCode(422, ModelState);
            }

            volMap.Itineraire = _itineraireRepository.GetItineraire(volCreate.ItineraireID);
            if (volMap.Itineraire == null)
            {
                ModelState.AddModelError("", "Cet itinéraire n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_volCargoRepository.CreateVol(volMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Nouveau vol ajouté avec succès");

        }


        [HttpPut("{volID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateVol(int volID, [FromBody] VolCargoDto volUpdate) 
        {
            if(volUpdate == null)
                return BadRequest(ModelState);
            
            if(volID != volUpdate.id) 
                return BadRequest(ModelState);

            if(!_volCargoRepository.VolExists(volID)) 
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var volMap = _mapper.Map<VolCargo>(volUpdate);

            if(!_volCargoRepository.UpdateVol(volMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du vol avec succès");
        }

    }
}
