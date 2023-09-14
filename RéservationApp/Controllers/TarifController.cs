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
    public class TarifController : Controller
    {
        private readonly ITarifRepository _tarifRepository;
        private readonly IMapper _mapper;

        public TarifController(ITarifRepository tarifRepository, IMapper mapper)
        {
            _tarifRepository = tarifRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tarif>))]

        public IActionResult Tarifs()
        {
            var tarifs = _mapper.Map<List<TarifDto>>(_tarifRepository.GetTarifs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tarifs);
        }

        [HttpGet("{TarifID}")]
        [ProducesResponseType(200, Type = typeof(Tarif))]
        [ProducesResponseType(400)]

        public IActionResult GetTarif(int TarifID)
        {
            if (!_tarifRepository.TarifExists(TarifID))
                return NotFound();

            var tarif = _mapper.Map<TarifDto>(_tarifRepository.GetTarif(TarifID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tarif);
        }
    }
}

