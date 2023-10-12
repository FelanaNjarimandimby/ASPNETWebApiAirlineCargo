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

        public CoutFretController(IMapper mapper, ICoutFretRepository coutFretRepository)
        {
            _mapper = mapper;
            _coutFretRepository = coutFretRepository;
        }

        [HttpGet("{Poids}")]
        [ProducesResponseType(200, Type = typeof(CoutFret))]
        [ProducesResponseType(400)]

        public IActionResult GetNatureByMarchandise(double Poids)
        {
            var coutfret = _mapper.Map<CoutFret>(_coutFretRepository.GetCoutFret(Poids));

            if (!ModelState.IsValid)
                return BadRequest();


            return Ok(coutfret);
        }
    }
}
