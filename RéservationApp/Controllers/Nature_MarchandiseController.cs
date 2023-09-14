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
    public class Nature_MarchandiseController : Controller
    {
        private readonly INature_MarchandiseRepository _nature_MarchandiseRepository;
        private readonly IMapper _mapper;

        public Nature_MarchandiseController(INature_MarchandiseRepository nature_MarchandiseRepository, IMapper mapper)
        {
            _nature_MarchandiseRepository = nature_MarchandiseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nature_Marchandise>))]

        public IActionResult GetNaure_Marchandises()
        {
            var nature_Marchandises = _mapper.Map<List<Nature_MarchandiseDto>>(_nature_MarchandiseRepository.GetNature_Marchandises());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nature_Marchandises);
        }

        [HttpGet("marchandises/{marchandiseID}")]
        [ProducesResponseType(200, Type = typeof(Nature_Marchandise))]
        [ProducesResponseType(400)]

        public IActionResult GetNatureByMarchandise(int marchandiseID)
        {
            var nature = _mapper.Map<Nature_MarchandiseDto>(
                _nature_MarchandiseRepository.GetNature_MarchandiseByMarchandise(marchandiseID));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(nature);
        }

        [HttpGet("{natureID}/marchandises")]

        public IActionResult GetMarchandiseFromNature(int natureID)
        {
            if (!_nature_MarchandiseRepository.Nature_MarchandiseExists(natureID))
                return NotFound();

            var marchandises = _mapper.Map<List<MarchandiseDto>>(
                _nature_MarchandiseRepository.GetMarchandiseFromNature(natureID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(marchandises);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        
        public IActionResult CreateNature_Marchandise([FromBody] Nature_MarchandiseDto natureCreate)
        {
            if(natureCreate == null)
                return BadRequest(ModelState);

            var nature = _nature_MarchandiseRepository.GetNature_Marchandises()
                .Where(nat => nat.Libelle.Trim().ToUpper() == natureCreate.Libelle.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (nature != null)
            {
                ModelState.AddModelError("", "Cette nature de marchandise existe déjà!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var natureMap = _mapper.Map<Nature_Marchandise>(natureCreate);

            if(!_nature_MarchandiseRepository.CreateNature_Marchandise(natureMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Nature de la marchandise ajoutée avec succès");
        }

        [HttpPut("{natureID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateNature_Marchandise(int natureID, [FromBody] Nature_MarchandiseDto natureUpdate)
        {
            if(natureUpdate == null)
                return BadRequest(ModelState);

            if(natureID != natureUpdate.IDNatureMarchandise)
                return BadRequest(ModelState);

            if(!_nature_MarchandiseRepository.Nature_MarchandiseExists(natureID))
                return NotFound();
            
            if (!ModelState.IsValid) 
                return BadRequest();

            var natureMap = _mapper.Map<Nature_Marchandise>(natureUpdate);

            if(!_nature_MarchandiseRepository.UpdateNature_Marchandise(natureMap))
            {
                ModelState.AddModelError("", "Le serveur a rencontré un problème");
                return StatusCode(500, ModelState);
            }

            return Ok("Modification de la nature de la marchandise avec succès");
        }

    }
}
