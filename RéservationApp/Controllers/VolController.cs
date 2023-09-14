using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RéservationApp.Dto;
using RéservationApp.Interfaces;
using RéservationApp.Models;
using RéservationApp.Repository;

namespace RéservationApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class VolController : Controller
    {
        private readonly IVolRepository _volRepository;
        private readonly IMapper _mapper;

        public VolController(IVolRepository volRepository, IMapper mapper)
        {
            _volRepository = volRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vol>))]

        public IActionResult Vols()
        {
            var vols = _mapper.Map<List<VolDto>>(_volRepository.GetVols());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vols);
        }

        [HttpGet("reservations/{reservationID}")]
        [ProducesResponseType(200, Type = typeof(Vol))]
        [ProducesResponseType(400)]

        public IActionResult GetVolByReservation(int reservationID)
        {
            var vol = _mapper.Map<VolDto>(
                _volRepository.GetVolByReservation(reservationID));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(vol);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateVol([FromBody] VolDto volCreate)
        {
            if (volCreate == null)
                return BadRequest(ModelState);

            var vol = _volRepository.GetVols()
                .Where(v => v.DateDepart == volCreate.DateDepart).FirstOrDefault();

            if (vol != null)
            {
                ModelState.AddModelError("", "Ce vol existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var volMap = _mapper.Map<Vol>(volCreate);

            if (!_volRepository.CreateVol(volMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Nouveau vol ajouté avec succès");
        }

        [HttpPut("{volNUM}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateVol(int volNUM, [FromBody] VolDto volUpdate) 
        {
            if(volUpdate == null)
                return BadRequest(ModelState);
            
            if(volNUM != volUpdate.NumVol) 
                return BadRequest(ModelState);

            if(!_volRepository.VolExists(volNUM)) 
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var volMap = _mapper.Map<Vol>(volUpdate);

            if(!_volRepository.UpdateVol(volMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification du vol avec succès");
                

        }

    }
}
