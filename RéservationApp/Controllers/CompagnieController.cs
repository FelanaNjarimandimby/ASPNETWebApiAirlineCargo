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
    public class CompagnieController : Controller
    {
        private readonly ICompagnieRepository _compagnieRepository;
        private readonly IMapper _mapper;

        public CompagnieController(ICompagnieRepository compagnieRepository, IMapper mapper)
        {
            _compagnieRepository = compagnieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Compagnie>))]

        public IActionResult Compagnies()
        {
            var compagnies = _mapper.Map<List<CompagnieDto>>(_compagnieRepository.GetCompagnies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(compagnies);
        }

        [HttpGet("{compagnieID}")]
        [ProducesResponseType(200, Type = typeof(Compagnie))]
        [ProducesResponseType(400)]

        public IActionResult GetCompagnie(int compagnieID)
        {
            if (!_compagnieRepository.CompagnieExists(compagnieID))
                return NotFound();

            var compagnie = _mapper.Map<CompagnieDto>(_compagnieRepository.GetCompagnie(compagnieID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(compagnie);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCompagnie([FromBody] CompagnieDto compagnieDto)
        {
            if (compagnieDto == null)
                return BadRequest(ModelState);

            var compagnie = _compagnieRepository.GetCompagnies()
                .Where(a => a.CompagnieNom.Trim().ToUpper() == compagnieDto.CompagnieNom.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (compagnie != null)
            {
                ModelState.AddModelError("", "Compagnie existe déjà");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var compagnieMap = _mapper.Map<Compagnie>(compagnieDto);

            if (!_compagnieRepository.CreateCompagnie(compagnieMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Compagnie ajouté avec succès");

        }

        [HttpPut("{compagnieID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateAgent(int compagnieID, [FromBody] CompagnieDto updatedCompagnie)
        {
            if (updatedCompagnie == null)
                return BadRequest(ModelState);

            if (compagnieID != updatedCompagnie.id)
                return BadRequest(ModelState);

            if (!_compagnieRepository.CompagnieExists(compagnieID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var compagnieMap = _mapper.Map<Compagnie>(updatedCompagnie);
            if (!_compagnieRepository.UpdateCompagnie(compagnieMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du compagnie avec succès");
        }

        [HttpDelete("{compagnieID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCompagnie(int compagnieID)
        {
            if (!_compagnieRepository.CompagnieExists(compagnieID))
            {
                return NotFound();
            }

            var compagnieDelete = _compagnieRepository.GetCompagnie(compagnieID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_compagnieRepository.DeleteCompagnie(compagnieDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Compagnie supprimée avec succès");
        }
    }
}
