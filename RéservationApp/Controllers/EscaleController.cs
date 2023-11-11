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
    public class EscaleController : Controller
    {
        private readonly IEscaleRepository _escaleRepository;
        private readonly IMapper _mapper;
        private readonly IVolCargoRepository _volCargoRepository;

        public EscaleController(IEscaleRepository escaleRepository, IMapper mapper, IVolCargoRepository volCargoRepository)
        {
            _escaleRepository = escaleRepository;
            _mapper = mapper;
            _volCargoRepository = volCargoRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Escale>))]

        public IActionResult Escales()
        {
            var escales = _mapper.Map<List<EscaleDto>>(_escaleRepository.GetEscales());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(escales);
        }

        [HttpGet("{escaleID}")]
        [ProducesResponseType(200, Type = typeof(Escale))]
        [ProducesResponseType(400)]

        public IActionResult GetEscale(int escaleID)
        {
            if (!_escaleRepository.EscaleExists(escaleID))
                return NotFound();

            var escale = _mapper.Map<EscaleDto>(_escaleRepository.GetEscaleID(escaleID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(escale);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateEscale([FromBody] EscaleDto escaleDto)
        {
            if (escaleDto == null)
                return BadRequest(ModelState);

            var escale = _escaleRepository.GetEscales()
                .Where(e => e.EscaleNumero == escaleDto.EscaleNumero)
                .FirstOrDefault();

            if (escale != null)
            {
                ModelState.AddModelError("", "Escale déjà! enregistré");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var escaleMap = _mapper.Map<Escale>(escaleDto);

            escaleMap.VolCargo = _volCargoRepository.GetVolCargo(escaleDto.VolID);
            if (escaleMap.VolCargo == null)
            {
                ModelState.AddModelError("", "Ce vol n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_escaleRepository.CreateEscale(escaleMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Escale ajouté avec succès");

        }

        [HttpPut("{escaleID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateEscale(int escaleID, [FromBody] EscaleDto updatedEscale)
        {
            if (updatedEscale == null)
                return BadRequest(ModelState);

            if (escaleID != updatedEscale.id)
                return BadRequest(ModelState);

            if (!_escaleRepository.EscaleExists(escaleID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var escaleMap = _mapper.Map<Escale>(updatedEscale);
            if (!_escaleRepository.UpdateEscale(escaleMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de l'escale avec succès");
        }

        [HttpDelete("{escaleID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteEscale(int escaleID)
        {
            if (!_escaleRepository.EscaleExists(escaleID))
                return NotFound();

            var escaleDelete = _escaleRepository.GetEscaleID(escaleID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_escaleRepository.DeleteEscale(escaleDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("Escale supprimé avec succès");
        }
    }
}
