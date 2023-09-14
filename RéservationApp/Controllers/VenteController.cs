using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;

namespace RéservationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController : Controller
    {
        private readonly IVenteRepository _venteRepository;
        private readonly IMapper _mapper;

        public VenteController(IVenteRepository venteRepository, IMapper mapper)
        {
            _venteRepository = venteRepository;    
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vente>))]
        
        public IActionResult GetVentes()
        {
            var ventes = _mapper.Map<List<VenteDto>>(_venteRepository.GetVentes());

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(ventes);
        }

        [HttpGet("{venteID}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Vente>))]
        [ProducesResponseType(400)]

        public IActionResult GetVente(int venteID)
        {
            if (!_venteRepository.VenteExists(venteID))
                return NotFound();

            var vente = _mapper.Map<VenteDto>(_venteRepository.GetVente(venteID));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vente);
        }
    }
}
