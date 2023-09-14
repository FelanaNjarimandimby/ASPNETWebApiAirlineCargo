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
    public class LtaController : Controller
    {
        private readonly ILtaRepository _ltaRepository;
        private readonly IMapper _mapper;

        public LtaController(ILtaRepository ltaRepository,IMapper mapper)
        {
            _ltaRepository = ltaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LTA>))]

        public IActionResult GetLta() 
        {
            var ltas = _mapper.Map<List<LtaDto>>(_ltaRepository.GetLtas());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ltas);
        }
        
        [HttpGet("{ltaID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LTA>))]
        [ProducesResponseType(400)]

        public IActionResult GetLta(int ltaID)
        {
            if (!_ltaRepository.LtaExists(ltaID))
                return NotFound();

            var lta = _mapper.Map<LtaDto>(_ltaRepository.GetLta(ltaID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(lta);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateLta([FromBody] LtaDto ltaCreate) 
        {
            if (ltaCreate == null)
                return BadRequest(ModelState);

            var lta = _ltaRepository.GetLtas().FirstOrDefault();

            if (lta != null)
            {
                ModelState.AddModelError("", "LTA existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ltaMap = _mapper.Map<LTA>(ltaCreate);

            if (!_ltaRepository.CreateLta(ltaMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("LTA ajouté avec succès");
        }
    }
}
