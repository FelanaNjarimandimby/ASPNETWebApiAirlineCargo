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
    public class AeroportController : Controller
    {
        private readonly IAeroportRepository _aeroportRepository;
        private readonly IMapper _mapper;
        private readonly ICompagnieRepository _compagnieRepository;

        public AeroportController(IAeroportRepository aeroportRepository, IMapper mapper, ICompagnieRepository compagnieRepository)
        {
            _aeroportRepository = aeroportRepository;
            _mapper = mapper;
            _compagnieRepository = compagnieRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Aeroport>))]

        public IActionResult Aeroports()
        {
            var aeroports = _mapper.Map<List<AeroportDto>>(_aeroportRepository.GetAeroports());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(aeroports);
        }

        [HttpGet("{aeroportID}")]
        [ProducesResponseType(200, Type = typeof(Aeroport))]
        [ProducesResponseType(400)]

        public IActionResult GetAeroport(int aeroportID)
        {
            if (!_aeroportRepository.AeroportExists(aeroportID))
                return NotFound();

            var aeroport = _mapper.Map<AeroportDto>(_aeroportRepository.GetAeroportID(aeroportID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(aeroport);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateAeroport([FromBody] AeroportDto aeroportDto)
        {
            if (aeroportDto == null)
                return BadRequest(ModelState);

            var aeroport = _aeroportRepository.GetAeroports()
                .Where(a => a.AeroportCodeIATA == aeroportDto.AeroportCodeIATA && a.AeroportCodeOACI == aeroportDto.AeroportCodeOACI)
                .FirstOrDefault();

            if (aeroport != null)
            {
                ModelState.AddModelError("", "Aéroport déjà! enregistré");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aeroportMap = _mapper.Map<Aeroport>(aeroportDto);


            aeroportMap.Compagnie = _compagnieRepository.GetCompagnie(aeroportDto.CompagnieID);
            if (aeroportMap.Compagnie == null)
            {
                ModelState.AddModelError("", "Ce compagnie n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_aeroportRepository.CreateAeroport(aeroportMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Aéroport ajouté avec succès");

        }

        [HttpPut("{aeroportID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateAeroport(int aeroportID, [FromBody] AeroportDto updatedAeroport)
        {
            if (updatedAeroport == null)
                return BadRequest(ModelState);

            if (aeroportID != updatedAeroport.id)
                return BadRequest(ModelState);

            if (!_aeroportRepository.AeroportExists(aeroportID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var aeroportMap = _mapper.Map<Aeroport>(updatedAeroport);
            if (!_aeroportRepository.UpdateAeroport(aeroportMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de l'aéroport avec succès");
        }

        [HttpDelete("{aeroportID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteAeroport(int aeroportID)
        {
            if (!_aeroportRepository.AeroportExists(aeroportID))
                return NotFound();

            var aeroportDelete = _aeroportRepository.GetAeroportID(aeroportID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_aeroportRepository.DeleteAeroport(aeroportDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Aéroport supprimé avec succès");
        }
    }
}
