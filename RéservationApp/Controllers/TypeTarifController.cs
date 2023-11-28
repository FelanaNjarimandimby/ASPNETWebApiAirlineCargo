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
    public class TypeTarifController : Controller
    {
        private readonly ITypeTarifRepository _typeTarifRepository;
        private readonly IMapper _mapper;

        public TypeTarifController(ITypeTarifRepository typeTarifRepository, IMapper mapper)
        {
            _typeTarifRepository = typeTarifRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TypeTarif>))]

        public IActionResult TypeTarifs()
        {
            var typeTarifs = _mapper.Map<List<TypeTarifDto>>(_typeTarifRepository.GetTypeTarifs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(typeTarifs);
        }

        [HttpGet("{TarifID}")]
        [ProducesResponseType(200, Type = typeof(TypeTarif))]
        [ProducesResponseType(400)]

        public IActionResult GetTypeTarif(int TarifID)
        {
            if (!_typeTarifRepository.TypeTarifExists(TarifID))
                return NotFound();

            var tarif = _mapper.Map<TypeTarifDto>(_typeTarifRepository.GetTypeTarif(TarifID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tarif);
        }

        [HttpGet("Tarif/{MarchandiseID}")]
        [ProducesResponseType(200, Type = typeof(TypeTarif))]
        [ProducesResponseType(400)]

        public IActionResult GetTypeByMarchandise(int MarchandiseID)
        {

            var tarif = _mapper.Map<TypeTarifDto>(_typeTarifRepository.GetTarifMarchandise(MarchandiseID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tarif);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateClient([FromBody] TypeTarifDto typeTarifDto)
        {
            if (typeTarifDto == null)
                return BadRequest(ModelState);

            var tarif = _typeTarifRepository.GetTypeTarifs()
                .Where(t => t.TarifLibelle.Trim().ToUpper() == typeTarifDto.TarifLibelle.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (tarif != null)
            {
                ModelState.AddModelError("", "Tarif existe déjà");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tarifMap = _mapper.Map<TypeTarif>(typeTarifDto);

            if (!_typeTarifRepository.CreateTypeTarif(tarifMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Type du tarif ajouté avec succès");

        }

        [HttpPut("{typeTarifID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateTarif(int typeTarifID, [FromBody] TypeTarifDto updatedTarif)
        {
            if (updatedTarif == null)
                return BadRequest(ModelState);

            if (typeTarifID != updatedTarif.id)
                return BadRequest(ModelState);

            if (!_typeTarifRepository.TypeTarifExists(typeTarifID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var typeTarifMap = _mapper.Map<TypeTarif>(updatedTarif);
            if (!_typeTarifRepository.UpdateTypeTarif(typeTarifMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du tarif avec succès");
        }

        [HttpDelete("{typeTarifID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteTarif(int typeTarifID)
        {
            if (!_typeTarifRepository.TypeTarifExists(typeTarifID))
            {
                return NotFound();
            }

            var tarifDelete = _typeTarifRepository.GetTypeTarif(typeTarifID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_typeTarifRepository.DeleteTypeTarif(tarifDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Tarif supprimé avec succès");
        }
    }
}

