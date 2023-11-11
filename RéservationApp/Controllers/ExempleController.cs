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
    public class ExempleController : Controller
    {
        private readonly IExempleRepository _exempleRepository;
        private readonly IMapper _mapper;

        public ExempleController(IExempleRepository exempleRepository, IMapper mapper)
        {
            _exempleRepository = exempleRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Exemple>))]
        public IActionResult GetExemples()
        {
            var exemples = _exempleRepository.GetExemples();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(exemples);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateExemple([FromBody] Exemple exemple)
        {
            
            var exMap = _mapper.Map<Exemple>(exemple);

            _exempleRepository.CreateExemple(exMap);

            return Ok("Exemple ajouté avec succès");

        }

    }
}
