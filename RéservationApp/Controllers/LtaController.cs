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
        private readonly IVenteRepository _venteRepository;

        public LtaController(ILtaRepository ltaRepository,IMapper mapper, IVenteRepository venteRepository)
        {
            _ltaRepository = ltaRepository;
            _mapper = mapper;
            _venteRepository = venteRepository;
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

        public IActionResult CreateLta([FromBody] LtaAdminDto ltaCreate) 
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

            ltaMap.Vente = _venteRepository.GetVente(ltaCreate.VenteID);
            if (ltaMap.Vente == null)
            {
                ModelState.AddModelError("", "Cette vente n'existe pas!");
                return StatusCode(422, ModelState);
            }

            if (!_ltaRepository.CreateLta(ltaMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("LTA ajouté avec succès");
        }

        [HttpPost("getID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult GetID(string LTANumero)
        {
            var lta = _mapper.Map<List<LtaDto>>(_ltaRepository.GetLtas()).Where(
                l => l.LTANumero == LTANumero).FirstOrDefault();

            if (lta == null)
                return BadRequest(ModelState);

            return Ok(lta);
        }

        [HttpPut("{ltaID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateLTA(int ltaID, [FromBody] LtaAdminDto updatedLta)
        {
            if (updatedLta == null)
                return BadRequest(ModelState);

            if (ltaID != updatedLta.id)
                return BadRequest(ModelState);

            if (!_ltaRepository.LtaExists(ltaID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ltaMap = _mapper.Map<LTA>(updatedLta);
            if (!_ltaRepository.UpdateLta(ltaMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du LTA avec succès");
        }

        [HttpDelete("{ltaID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteLTA(int ltaID)
        {
            if (!_ltaRepository.LtaExists(ltaID))
                return NotFound();

            var ltaDelete = _ltaRepository.GetLta(ltaID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ltaRepository.DeleteLta(ltaDelete))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
            }

            return Ok("LTA supprimé avec succès");
        }
    }
}
