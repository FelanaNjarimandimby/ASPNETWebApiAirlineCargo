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
    public class CoutFretController: Controller
    {
        private readonly IMapper _mapper;
        private readonly ICoutFretRepository _coutFretRepository;
        private readonly IAgentRepository _agentRepository;

        public CoutFretController(IMapper mapper, ICoutFretRepository coutFretRepository, IAgentRepository agentRepository)
        {
            _mapper = mapper;
            _coutFretRepository = coutFretRepository;
            _agentRepository = agentRepository;
        }

        [HttpGet("Trouver/{Poids}")]
        [ProducesResponseType(200, Type = typeof(CoutFret))]
        [ProducesResponseType(400)]

        public IActionResult GetPoidsInCout(double Poids)
        {
            var coutfret = _mapper.Map<CoutFretDto>(_coutFretRepository.GetCoutFret(Poids));

            if (!ModelState.IsValid)
                return BadRequest();


            return Ok(coutfret);

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoutFret>))]

        public IActionResult CoutFrets()
        {
            var coutFrets = _mapper.Map<List<CoutDto>>(_coutFretRepository.GetCoutFrets());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coutFrets);
        }

        [HttpGet("Chart")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoutFret>))]

        public IActionResult CoutFretChart()
        {
            var coutFrets = _mapper.Map<List<CoutDto>>(_coutFretRepository.GetCoutFrets());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coutFrets);
        }

        [HttpGet("{coutFretID}")]
        [ProducesResponseType(200, Type = typeof(CoutFret))]
        [ProducesResponseType(400)]

        public IActionResult GetCoutFret(int coutFretID)
        {
            if (!_coutFretRepository.CoutFretExists(coutFretID))
                return NotFound();

            var coutFret = _mapper.Map<CoutFretDto>(_coutFretRepository.GetCoutFretID(coutFretID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coutFret);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCoutFret([FromBody] CoutFretDto coutFretDto)
        {
                if (coutFretDto == null)
                    return BadRequest(ModelState);

                var cout = _coutFretRepository.GetCoutFrets()
                    .Where(cf => cf.CoutPoidsMin == coutFretDto.CoutPoidsMin && cf.CoutPoidsMax == coutFretDto.CoutPoidsMax)
                    .FirstOrDefault();

                if (cout != null)
                {
                    ModelState.AddModelError("", "Cout de fret existe déjà!");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var coutMap = _mapper.Map<CoutFret>(coutFretDto);


                coutMap.Agent = _agentRepository.GetAgent(coutFretDto.AgentID);
                if (coutMap.Agent == null)
                {
                    ModelState.AddModelError("", "Cet agent n'existe pas!");
                    return StatusCode(422, ModelState);
                }

                if (!_coutFretRepository.CreateCoutFret(coutMap))
                {
                    ModelState.AddModelError("", "Le serveur a rencontré un problème");
                    return StatusCode(500, ModelState);
                }

                return Ok("Cout de fret ajouté avec succès");

        }

        [HttpPut("{coutID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateCoutFret(int coutID, [FromBody] CoutFretDto updatedCout)
        {
            if (updatedCout == null)
                return BadRequest(ModelState);

            if (coutID != updatedCout.id)
                return BadRequest(ModelState);

            if (!_coutFretRepository.CoutFretExists(coutID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var coutMap = _mapper.Map<CoutFret>(updatedCout);
            if (!_coutFretRepository.UpdateCoutFret(coutMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du cout de fret avec succès");
        }

    [HttpDelete("{coutID}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]

    public IActionResult DeleteCoutFret(int coutID)
    {
        if (!_coutFretRepository.CoutFretExists(coutID))
            return NotFound();

        var coutDelete = _coutFretRepository.GetCoutFret(coutID);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_coutFretRepository.DeleteCoutFret(coutDelete))
        {
            ModelState.AddModelError("", "Le serveur a rencontré un problème");
        }

        return Ok("Cout de fret supprimé avec succès");
    }
}
}
