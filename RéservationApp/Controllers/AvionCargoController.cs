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
    public class AvionCargoController : Controller
    {
        private readonly IAvionCargoRepository _avionCargoRepository;
        private readonly IMapper _mapper;

        public AvionCargoController(IAvionCargoRepository avionCargoRepository, IMapper mapper)
        {
            _avionCargoRepository = avionCargoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AvionCargo>))]

        public IActionResult IAvionCargos()
        {
            var avions = _mapper.Map<List<AvionCargoDto>>(_avionCargoRepository.GetAvionCargos());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(avions);
        }

        [HttpGet("{avionID}")]
        [ProducesResponseType(200, Type = typeof(AvionCargo))]
        [ProducesResponseType(400)]

        public IActionResult GetAvionCargo(int avionID)
        {
            if (!_avionCargoRepository.AvionExists(avionID))
                return NotFound();

            var avion = _mapper.Map<AvionCargoDto>(_avionCargoRepository.GetAvion(avionID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(avion);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateAgent([FromBody] AvionCargoDto avionDto)
        {
            if (avionDto == null)
                return BadRequest(ModelState);

            var avion = _avionCargoRepository.GetAvionCargos()
                .Where(a => a.AvionModele == avionDto.AvionModele).FirstOrDefault();

            if (avion != null)
            {
                ModelState.AddModelError("", "Avion déjà enregistré");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var avionMap = _mapper.Map<AvionCargo>(avionDto);

            if (!_avionCargoRepository.CreateAvion(avionMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Avion ajouté avec succès");

        }

        [HttpPut("{avionID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateAvion(int avionID, [FromBody] AvionCargoDto updatedAvion)
        {
            if (updatedAvion == null)
                return BadRequest(ModelState);

            if (avionID != updatedAvion.id)
                return BadRequest(ModelState);

            if (!_avionCargoRepository.AvionExists(avionID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var avionMap = _mapper.Map<AvionCargo>(updatedAvion);
            if (!_avionCargoRepository.UpdateAvion(avionMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de l'avion avec succès");
        }

        [HttpDelete("{avionID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteAvion(int avionID)
        {
            if (!_avionCargoRepository.AvionExists(avionID))
            {
                return NotFound();
            }

            var avionDelete = _avionCargoRepository.GetAvion(avionID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_avionCargoRepository.DeleteAvion(avionDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Avion supprimé avec succès");
        }
    }
}
